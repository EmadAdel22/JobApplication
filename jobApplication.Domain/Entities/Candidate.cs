using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace jobApplication.Domain.Entities
{
    public class Candidate
    {
        public int Id { get; set; }

        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public string Name { get; set; }
        public string? CvUrl { get; set; }

        public ICollection<JobCandidateApplication> JobApplications { get; set; }

    }
}
