using jobApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
