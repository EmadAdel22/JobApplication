using jobApplication.Application.DTOs;
using jobApplication.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Interfaces
{
    public interface IAuthService
    {
        Task<int> RegisterAsync(RegisterDTO RegisterDTO);

        Task<LoginResponseDTO> LoginAsync(LoginDTO LoginDTO);
    }
}
