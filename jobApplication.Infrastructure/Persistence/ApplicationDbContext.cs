using Microsoft.EntityFrameworkCore;
using jobApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Job> jobs { get; set; }
        public DbSet<Candidate> candidates { get; set; }

        public DbSet<JobCandidateApplication> JobCandidateApplications { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }


    }
}
