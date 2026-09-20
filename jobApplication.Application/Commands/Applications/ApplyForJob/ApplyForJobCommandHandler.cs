using jobApplication.Application.Interfaces;
using jobApplication.Domain.Entities;
using jobApplication.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Commands.Applications.ApplyForJob
{
    public class ApplyForJobCommandHandler : IRequestHandler<ApplyForJobCommand, int>
    {

        private readonly IJobRepository _jobRepository;
        private readonly ICandidateRepository _candidateRepository;
        private readonly IJobCandidateApplicationRepository _applicationRepository;

        public ApplyForJobCommandHandler(
            IJobRepository jobRepository,
            ICandidateRepository candidateRepository,
            IJobCandidateApplicationRepository applicationRepository)
        {
            _jobRepository = jobRepository;
            _candidateRepository = candidateRepository;
            _applicationRepository = applicationRepository;
        }
        public async Task<int> Handle(ApplyForJobCommand request,CancellationToken cancellationToken)
        {
            var candidate = _candidateRepository
                .Get()
                .FirstOrDefault(x => x.UserId == request.UserId);

            if (candidate == null)
                throw new Exception("Candidate not found.");

            var job = _jobRepository
                .Get()
                .FirstOrDefault(x => x.Id == request.JobId);

            if (job == null)
                throw new Exception("Job not found.");

            if (!job.IsActive)
                throw new Exception(
                    "This job is no longer accepting applications.");

            var existingApplication = _applicationRepository
                .Get()
                .FirstOrDefault(x =>
                    x.CandidateId == candidate.Id &&
                    x.JobId == request.JobId);

            if (existingApplication != null)
                throw new Exception(
                    "You have already applied for this job.");

            var application = new JobCandidateApplication
            {
                CandidateId = candidate.Id,
                JobId = job.Id,
                JobApplicationStatus = JobApplicationStatus.Applied,
                AppliedAt = DateTime.UtcNow,
                StatusUpdatedAt = DateTime.UtcNow
            };

            await _applicationRepository.InsertAsync(application);
            await _applicationRepository.SaveChangesAsync();

            return application.Id;
        }
    }
}
