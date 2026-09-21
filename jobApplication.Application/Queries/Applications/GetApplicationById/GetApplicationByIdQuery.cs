using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Queries.Applications.GetApplicationById
{
    public class GetApplicationByIdQuery
      : IRequest<GetApplicationByIdResponseDTO>
    {
        public int ApplicationId { get; set; }
    }
}
