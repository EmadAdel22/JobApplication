using jobApplication.Application.Interfaces;
using jobApplication.Domain.Entities;
using jobApplication.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Infrastructure.Reposatpories
{
    public class JobRepository : IJobRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public JobRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Job> Get()
        {
            var jobs = _dbContext.jobs.AsQueryable();
            return jobs;
        }

        public async Task InsertAsync(Job job)
        {
            await _dbContext.jobs.AddAsync(job);
        }

        public void Remove(Job job)
        {
            _dbContext.jobs.Remove(job);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Update(Job job)
        {
            _dbContext.jobs.Update(job);
        }
    }
}
