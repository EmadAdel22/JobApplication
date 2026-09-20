using jobApplication.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Queries.Jobs.GetJobById
{
    public class GetJobByIdQueryHandler
        : IRequestHandler<GetJobByIdQuery, GetJobByIdResponseDTO>
    {
        private readonly IJobRepository _jobRepository;

        public GetJobByIdQueryHandler(
            IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<GetJobByIdResponseDTO> Handle(
            GetJobByIdQuery request,
            CancellationToken cancellationToken)
        {
            var job = _jobRepository
                .Get()
                .FirstOrDefault(x => x.Id == request.Id);

            if (job == null)
                throw new Exception("Job not found.");

            return new GetJobByIdResponseDTO
            {
                Id = job.Id,
                Title = job.Title,
                Description = job.Description,
                IsActive = job.IsActive,
                ClosedAt = job.ClosedAt
            };
        }
    }
}
