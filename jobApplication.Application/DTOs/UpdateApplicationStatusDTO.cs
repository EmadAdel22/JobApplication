using jobApplication.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.DTOs
{
    public class UpdateApplicationStatusDTO
    {

        public JobApplicationStatus Status { get; set; }
    }
}
