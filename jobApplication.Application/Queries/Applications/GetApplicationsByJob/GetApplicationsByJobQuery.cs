using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Queries.Applications.GetApplicationsByJob
{
    public class GetApplicationsByJobQuery
      : IRequest<List<GetApplicationsByJobResponseDTO>>
    {
        public int JobId { get; set; }
    }
}
