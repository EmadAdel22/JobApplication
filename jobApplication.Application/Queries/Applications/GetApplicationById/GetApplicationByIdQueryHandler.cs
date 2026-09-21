using jobApplication.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Queries.Applications.GetApplicationById
{
    public class GetApplicationByIdQueryHandler
      : IRequestHandler<
          GetApplicationByIdQuery,
          GetApplicationByIdResponseDTO>
    {
        private readonly IJobCandidateApplicationRepository
            _applicationRepository;

        public GetApplicationByIdQueryHandler(
            IJobCandidateApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<GetApplicationByIdResponseDTO> Handle(
            GetApplicationByIdQuery request,
            CancellationToken cancellationToken)
        {
            var application = _applicationRepository
                .Get()
                .Where(x => x.Id == request.ApplicationId)
                .Select(x => new GetApplicationByIdResponseDTO
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
                .FirstOrDefault();

            if (application == null)
                throw new Exception("Application not found.");

            return await Task.FromResult(application);
        }
    }
}
