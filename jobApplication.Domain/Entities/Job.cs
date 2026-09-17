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
        public bool IsActive { get; set; }

        public ICollection<JobCandidateApplication> Applications { get; set; }

    }
}
