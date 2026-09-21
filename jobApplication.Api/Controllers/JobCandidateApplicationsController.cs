using jobApplication.Application.Commands.Applications.ApplyForJob;
using jobApplication.Application.Commands.Applications.CancelApplication;
using jobApplication.Application.Commands.Applications.UpdateApplicationStatus;
using jobApplication.Application.DTOs;
using jobApplication.Application.Interfaces;
using jobApplication.Application.Queries.Applications.GetApplicationById;
using jobApplication.Application.Queries.Applications.GetApplicationsByJob;
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


  

        [Authorize(Roles = "Recruiter")]
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(
    int id,
    UpdateApplicationStatusCommand command)
        {
            command.ApplicationId = id;

            await _mediator.Send(command);

            return Ok(new
            {
                Message = "Application status updated successfully."
            });
        }

       // [Authorize(Roles = "Recruiter")]
        [HttpGet("job/{jobId}")]
        public async Task<IActionResult> GetByJob(int jobId)
        {
            var query = new GetApplicationsByJobQuery
            {
                JobId = jobId
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

       // [Authorize(Roles = "Recruiter")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetApplicationByIdQuery
            {
                ApplicationId = id
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }


}


    