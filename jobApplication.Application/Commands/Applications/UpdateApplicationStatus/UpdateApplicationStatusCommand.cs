using jobApplication.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Commands.Applications.UpdateApplicationStatus
{
    public class UpdateApplicationStatusCommand : IRequest
    {
        public int ApplicationId { get; set; }

        public JobApplicationStatus Status { get; set; }
    }
}
