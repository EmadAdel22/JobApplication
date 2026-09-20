using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Queries.Jobs.GetJobById
{
    public class GetJobByIdQuery: IRequest<GetJobByIdResponseDTO>
    {
        public int Id { get; set; }
    }
}
