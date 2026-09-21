using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Queries.Applications.GetApplicationsByJob
{
    public class GetApplicationsByJobResponseDTO
    {
        public int ApplicationId { get; set; }

        public int CandidateId { get; set; }

        public string CandidateName { get; set; }

        public string CvUrl { get; set; }

        public int JobId { get; set; }

        public string JobTitle { get; set; }

        public string Status { get; set; }

        public DateTime AppliedAt { get; set; }

        public DateTime StatusUpdatedAt { get; set; }

        public DateTime? CancelledAt { get; set; }
    }
}
