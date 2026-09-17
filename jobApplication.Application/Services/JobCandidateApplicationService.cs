using jobApplication.Application.DTOs;
using jobApplication.Application.Interfaces;
using jobApplication.Domain.Entities;
using jobApplication.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Services
{
    public class JobCandidateApplicationService : IJobCandidateApplicationService
    {

        private readonly IJobCandidateApplicationRepository _applicationRepository;
        private readonly IJobRepository _jobRepository;
        private readonly ICandidateRepository _candidateRepository;

        public JobCandidateApplicationService(
            IJobCandidateApplicationRepository applicationRepository,
            IJobRepository jobRepository,
            ICandidateRepository candidateRepository)
        {
            _applicationRepository = applicationRepository;
            _jobRepository = jobRepository;
            _candidateRepository = candidateRepository;
        }

        public async Task<int> ApplyAsync(ApplyJobDTO ApplyJobDTO)
        {
            var candidate = _candidateRepository
                            .Get()
                            .FirstOrDefault(x => x.Id == ApplyJobDTO.CandidateId);

            if (candidate == null)
                throw new Exception("Candidate not found.");

            var job = _jobRepository
                .Get()
                .FirstOrDefault(x => x.Id == ApplyJobDTO.JobId);

            if (job == null)
                throw new Exception("Job not found.");

            if (!job.IsActive)
                throw new Exception("This job is no longer accepting applications.");

            var existingApplication = _applicationRepository
                .Get()
                .FirstOrDefault(x =>
                    x.CandidateId == ApplyJobDTO.CandidateId &&
                    x.JobId == ApplyJobDTO.JobId &&
                    x.JobApplicationStatus != JobApplicationStatus.Cancelled);

            if (existingApplication != null)
                throw new Exception("Candidate has already applied for this job."); 

            var application = new JobCandidateApplication
            {
                CandidateId = ApplyJobDTO.CandidateId,
                JobId = ApplyJobDTO.JobId,
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
