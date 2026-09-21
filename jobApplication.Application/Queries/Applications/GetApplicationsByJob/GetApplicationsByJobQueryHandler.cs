using jobApplication.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Queries.Applications.GetApplicationsByJob
{
    public class GetApplicationsByJobQueryHandler
       : IRequestHandler<
           GetApplicationsByJobQuery,
           List<GetApplicationsByJobResponseDTO>>
    {
        private readonly IJobCandidateApplicationRepository
            _applicationRepository;

        public GetApplicationsByJobQueryHandler(
            IJobCandidateApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<List<GetApplicationsByJobResponseDTO>> Handle(
            GetApplicationsByJobQuery request,
            CancellationToken cancellationToken)
        {
            var applications = _applicationRepository
                .Get()
                .Where(x => x.JobId == request.JobId)
                .Select(x => new GetApplicationsByJobResponseDTO
                {
                    ApplicationId = x.Id,
                    CandidateId = x.CandidateId,
                    CandidateName = x.Candidate.Name,
                    CvUrl = x.Candidate.CvUrl,

                    JobId = x.JobId,
                    JobTitle = x.Job.Title,

                    Status = x.JobApplicationStatus.ToString(),

                    AppliedAt = x.AppliedAt,
                    StatusUpdatedAt = x.StatusUpdatedAt,
                    CancelledAt = x.CancelledAt
                })
                .ToList();

            return await Task.FromResult(applications);
        }
    }
}
