using jobApplication.Application.DTOs.Auth;
using jobApplication.Application.Interfaces;
using jobApplication.Domain.Entities;
using jobApplication.Domain.Enum;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Text;
using jobApplication.Application.DTOs;

namespace jobApplication.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICandidateRepository _candidateRepository;
        private readonly IJwtService _jwtService;
        public AuthService(IUserRepository userRepository, ICandidateRepository candidateRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _candidateRepository = candidateRepository;
            _jwtService = jwtService;
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
            var candidate = new Candidate
            {
                User = user,
                Name = RegisterDTO.Name
            };

            await _candidateRepository.InsertAsync(candidate);

            await _userRepository.SaveChangesAsync();


            return user.Id;
        }




        public async Task<LoginResponseDTO> LoginAsync(LoginDTO LoginDTO)
        {
            var user = _userRepository
                .Get()
                .FirstOrDefault(x => x.Email == LoginDTO.Email);

            if (user == null)
                throw new Exception("Invalid email or password.");

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(
                LoginDTO.Password,
                user.PasswordHash);

            if (!isPasswordValid)
                throw new Exception("Invalid email or password.");

            var token = _jwtService.GenerateToken(user);

            return new LoginResponseDTO
            {
                Token = token,
                UserId = user.Id,
                Name = user.Name,
                Role = user.Role.ToString()
            };
        }


    }
}
