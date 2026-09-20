using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Queries.Jobs.GetJobById
{
    public class GetJobByIdResponseDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime? ClosedAt { get; set; }
    }
}
