using jobApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> Get();

        Task InsertAsync(User user);

        void Update(User user);

        Task SaveChangesAsync();
    }
}
