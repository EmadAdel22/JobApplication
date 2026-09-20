using jobApplication.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Queries.Jobs.GetJobs
{
    public class GetJobsQueryHandler
       : IRequestHandler<GetJobsQuery, List<GetJobsResponseDTO>>
    {
        private readonly IJobRepository _jobRepository;

        public GetJobsQueryHandler(
            IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<List<GetJobsResponseDTO>> Handle(
            GetJobsQuery request,
            CancellationToken cancellationToken)
        {
            var jobs = _jobRepository
                .Get()
                .Select(x => new GetJobsResponseDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    IsActive = x.IsActive,
                    ClosedAt = x.ClosedAt
                })
                .ToList();

            return await Task.FromResult(jobs);
        }
    }
}
