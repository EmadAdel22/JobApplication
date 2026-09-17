using jobApplication.Application.Interfaces;
using jobApplication.Domain.Entities;
using jobApplication.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Infrastructure.Reposatpories
{
    public class JobCandidateApplicationRepository : IJobCandidateApplicationRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public JobCandidateApplicationRepository(
            ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<JobCandidateApplication> Get()
        {
            var applications = _dbContext.JobCandidateApplications.AsQueryable();

            return applications;
        }

        public async Task InsertAsync(JobCandidateApplication application)
        {
            await _dbContext.JobCandidateApplications.AddAsync(application);
        }

        public void Remove(JobCandidateApplication application)
        {
            _dbContext.JobCandidateApplications.Remove(application);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Update(JobCandidateApplication application)
        {
            _dbContext.JobCandidateApplications.Update(application);
        }
    }
}
