using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Commands.Jobs.CreateJob
{
    public class CreateJobCommand : IRequest<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
