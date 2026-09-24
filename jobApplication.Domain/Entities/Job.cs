using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Domain.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? ClosedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<JobCandidateApplication> Applications { get; set; }

    }
}
