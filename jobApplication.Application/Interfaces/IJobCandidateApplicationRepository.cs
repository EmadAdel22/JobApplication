using jobApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Interfaces
{
    public interface IJobCandidateApplicationRepository
    {
        Task InsertAsync(JobCandidateApplication application);

        void Update(JobCandidateApplication application);

        IQueryable<JobCandidateApplication> Get();

        void Remove(JobCandidateApplication application);

        Task SaveChangesAsync();
    }
}
