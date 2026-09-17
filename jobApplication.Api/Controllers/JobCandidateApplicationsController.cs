using jobApplication.Application.DTOs;
using jobApplication.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace jobApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCandidateApplicationsController : ControllerBase
    {
        private readonly IJobCandidateApplicationService _applicationService;

        public JobCandidateApplicationsController(
            IJobCandidateApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Apply(ApplyJobDTO dto)
        {
            var id = await _applicationService.ApplyAsync(dto);

            return Ok(new
            {
                Id = id,
                Message = "Application submitted successfully."
            });
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> Cancel(int id)
        {
            await _applicationService.CancelAsync(id);

            return Ok(new
            {
                Message = "Application cancelled successfully."
            });
        }

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