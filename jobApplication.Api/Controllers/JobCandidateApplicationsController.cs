using jobApplication.Application.Commands.Applications.ApplyForJob;
using jobApplication.Application.Commands.Applications.CancelApplication;
using jobApplication.Application.DTOs;
using jobApplication.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace jobApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCandidateApplicationsController : ControllerBase
    {
        private readonly IJobCandidateApplicationService _applicationService;

        private readonly IMediator _mediator;

        public JobCandidateApplicationsController(
            IJobCandidateApplicationService applicationService, IMediator mediator)
        {
            _applicationService = applicationService;
            _mediator = mediator;
        }


        [Authorize(Roles = "Candidate")]
        [HttpPost]
        public async Task<IActionResult> Apply(ApplyForJobCommand command)
        {
            var userId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier));

            command.UserId = userId;

            var applicationId = await _mediator.Send(command);

            return Ok(new
            {
                Id = applicationId,
                Message = "Application submitted successfully."
            });
        }



        [Authorize(Roles = "Candidate")]
        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> Cancel(int id)
        {
            var userId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier));

            var command = new CancelApplicationCommand
            {
                ApplicationId = id,
                UserId = userId
            };

            await _mediator.Send(command);

            return Ok(new
            {
                Message = "Application cancelled successfully."
            });
        }


        //    [HttpPut("{id}/status")]
        //    public async Task<IActionResult> UpdateStatus(
        //int id,
        //UpdateApplicationStatusDTO dto)
        //    {
        //        await _applicationService.UpdateStatusAsync(id, dto);

        //        return Ok(new
        //        {
        //            Message = "Application status updated successfully."
        //        });
        //    }


        [Authorize(Roles = "Recruiter")]
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(
    int id,
    UpdateApplicationStatusDTO dto)
        {
            await _applicationService.UpdateStatusAsync(id, dto);

            return Ok(new
            {
                Message = "Application status updated successfully."
            });
        }
    }
}