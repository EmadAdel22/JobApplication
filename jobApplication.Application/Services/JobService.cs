using jobApplication.Application.DTOs;
using jobApplication.Application.Interfaces;
using jobApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Services
{
    public class JobService 
    {
        private readonly IJobRepository _jobRepository;
        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<int> CreateAsync(AddJobDTO jobDTo)
        {
            var job = new Job
            {
                Title = jobDTo.Title,

                Description = jobDTo.Description,

                IsActive = true

            };

            await _jobRepository.InsertAsync(job);
            await _jobRepository.SaveChangesAsync();

            return job.Id;
        }

    }
}
