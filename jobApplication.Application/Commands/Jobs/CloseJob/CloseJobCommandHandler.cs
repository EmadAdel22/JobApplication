using jobApplication.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Commands.Jobs.CloseJob
{
    public class CloseJobCommandHandler
    : IRequestHandler<CloseJobCommand>
    {
        private readonly IJobRepository _jobRepository;

        public CloseJobCommandHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task Handle(
            CloseJobCommand request,
            CancellationToken cancellationToken)
        {
            var job = _jobRepository
                .Get()
                .FirstOrDefault(x => x.Id == request.JobId);

            if (job == null)
                throw new Exception("Job not found.");

            if (!job.IsActive)
                throw new Exception("Job is already closed.");

            job.IsActive = false;
            job.ClosedAt = DateTime.UtcNow;

            _jobRepository.Update(job);

            await _jobRepository.SaveChangesAsync();
        }
    }
}
