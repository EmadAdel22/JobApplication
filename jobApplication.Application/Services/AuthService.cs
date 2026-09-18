using jobApplication.Application.DTOs.Auth;
using jobApplication.Application.Interfaces;
using jobApplication.Domain.Entities;
using jobApplication.Domain.Enum;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobApplication.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> RegisterAsync(RegisterDTO RegisterDTO)
        {
            var existingUser = _userRepository
                .Get()
                .FirstOrDefault(x => x.Email == RegisterDTO.Email);

            if (existingUser != null)
                throw new Exception("Email already exists.");

            var user = new User
            {
                Name = RegisterDTO.Name,
                Email = RegisterDTO.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(RegisterDTO.Password),
                Role = UserRole.Candidate
            };

            await _userRepository.InsertAsync(user);

            await _userRepository.SaveChangesAsync();

            return user.Id;
        }


        public Task LoginAsync(LoginDTO LoginDTO)
        {
            throw new NotImplementedException();
        }

       
    }
}
