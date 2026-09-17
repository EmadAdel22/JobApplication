using jobApplication.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Interfaces
{
  
        public interface IJobCandidateApplicationService
        {
            Task<int> ApplyAsync(ApplyJobDTO dto);
        }
    
}
