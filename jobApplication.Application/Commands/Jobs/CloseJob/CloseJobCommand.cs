using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Commands.Jobs.CloseJob
{
    public class CloseJobCommand : IRequest
    {
        public int JobId { get; set; }

    }
}
