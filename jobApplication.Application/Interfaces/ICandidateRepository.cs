using jobApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Interfaces
{
    
        public interface ICandidateRepository
        {
            IQueryable<Candidate> Get();

            Task InsertAsync(Candidate candidate);

            void Update(Candidate candidate);

            void Remove(Candidate candidate);

            Task SaveChangesAsync();
        }
    
}
