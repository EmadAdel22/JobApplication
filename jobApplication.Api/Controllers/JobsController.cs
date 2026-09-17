using jobApplication.Application.DTOs;
using jobApplication.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jobApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly JobService _jobService;
        public JobsController(JobService jobService)
        {
            _jobService = jobService;
        }

        [HttpPost]

        public async Task<IActionResult> Creat(AddJobDTO jobDTo)
        {
         var id=  await _jobService.CreateAsync(jobDTo);

            return Ok(new { Id = id });

        }

    }
}
