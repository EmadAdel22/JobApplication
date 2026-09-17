using System;
using System.Collections.Generic;
using System.Text;
using jobApplication.Domain.Entities;

namespace jobApplication.Application.Interfaces
{
    public interface IJobRepository
    {
        Task InsertAsync(Job job);
        void Update(Job job);
        IQueryable<Job> Get();
        void Remove(Job job);
        Task SaveChangesAsync();

    }
}
