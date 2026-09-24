using jobApplication.Application.Interfaces;
using jobApplication.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Commands.Jobs.CreateJob
{
    public class CreateJobCommandHandler
       : IRequestHandler<CreateJobCommand, int>
    {
        private readonly IJobRepository _jobRepository;

        public CreateJobCommandHandler(
            IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<int> Handle(
            CreateJobCommand request,
            CancellationToken cancellationToken)
        {
            var job = new Job
            {
                Title = request.Title,
                Description = request.Description,
                IsActive = true,
                CreatedAt = DateTime.UtcNow

            };

            await _jobRepository.InsertAsync(job);

            await _jobRepository.SaveChangesAsync();

            return job.Id;
        }
    }
}
