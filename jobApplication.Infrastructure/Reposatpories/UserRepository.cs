using jobApplication.Application.Interfaces;
using jobApplication.Domain.Entities;
using jobApplication.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Infrastructure.Reposatpories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<User> Get()
        {
           return _dbContext.users.AsQueryable();
        }

        public async Task InsertAsync(User user)
        {
            await _dbContext.users.AddAsync(user);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Update(User user)
        {
            _dbContext.users.Update(user);
        }
    }
}
