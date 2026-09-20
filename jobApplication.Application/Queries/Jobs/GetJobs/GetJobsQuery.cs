using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Queries.Jobs.GetJobs
{
    public class GetJobsQuery : IRequest<List<GetJobsResponseDTO>>
    {
    }
}
