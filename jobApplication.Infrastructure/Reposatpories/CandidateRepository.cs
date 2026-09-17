using jobApplication.Application.Interfaces;
using jobApplication.Domain.Entities;
using jobApplication.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Infrastructure.Reposatpories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CandidateRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Candidate> Get()
        {
            return _dbContext.candidates.AsQueryable();
        }

        public async Task InsertAsync(Candidate candidate)
        {
            await _dbContext.candidates.AddAsync(candidate);
        }

        public void Update(Candidate candidate)
        {
            _dbContext.candidates.Update(candidate);
        }

        public void Remove(Candidate candidate)
        {
            _dbContext.candidates.Remove(candidate);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
