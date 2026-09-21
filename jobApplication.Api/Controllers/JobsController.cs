using jobApplication.Application.Commands.Jobs.CloseJob;
using jobApplication.Application.Commands.Jobs.CreateJob;
using jobApplication.Application.DTOs;
using jobApplication.Application.Queries.Jobs.GetJobById;
using jobApplication.Application.Queries.Jobs.GetJobs;
using jobApplication.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jobApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly JobService _jobService;

        public JobsController(IMediator mediator, JobService jobService)
        {
            _mediator = mediator;
            _jobService = jobService;
        }


        // GET: api/Jobs
        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var query = new GetJobsQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        // GET: api/Jobs/id

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetJobByIdQuery
            {
                Id = id
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [Authorize(Roles = "Recruiter")]
        [HttpPost]
        public async Task<IActionResult> Create(
            CreateJobCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(new
            {
                Id = id
            });
        }


        [Authorize(Roles = "Recruiter")]
        [HttpPut("{id}/close")]
        public async Task<IActionResult> Close(int id)
        {
            var command = new CloseJobCommand
            {
                JobId = id
            };

            await _mediator.Send(command);

            return Ok(new
            {
                Message = "Job closed successfully."
            });
        }

    }
}
