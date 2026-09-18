using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.DTOs
{
    
        public class LoginResponseDTO
        {
            public string Token { get; set; }

            public int UserId { get; set; }

            public string Name { get; set; }

            public string Role { get; set; }
        }
    
}
