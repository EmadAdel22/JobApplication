using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Commands.Applications.CancelApplication
{
    public class CancelApplicationCommand : IRequest
    {
        public int ApplicationId { get; set; }

        public int UserId { get; set; }
    }
}
