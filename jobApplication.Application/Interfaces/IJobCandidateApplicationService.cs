using jobApplication.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Interfaces
{
  
        public interface IJobCandidateApplicationService
        {
            Task<int> ApplyAsync(ApplyJobDTO dto);
       // Task ApplyAsync(ApplyJobDTO dto, int userId);


        Task CancelAsync(int applicationId);
       // Task CancelAsync(int applicationId, int userId);

        Task UpdateStatusAsync(int applicationId, UpdateApplicationStatusDTO dto);


    }

}
