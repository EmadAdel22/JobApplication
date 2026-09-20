using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Commands.Applications.ApplyForJob
{
    public class ApplyForJobCommand : IRequest<int>
    {
        public int JobId { get; set; }

        public int UserId { get; set; }

    }
}
