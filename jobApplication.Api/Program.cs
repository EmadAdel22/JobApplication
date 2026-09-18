using jobApplication.Application.Interfaces;
using jobApplication.Application.Services;
using jobApplication.Infrastructure.Persistence;
using jobApplication.Infrastructure.Reposatpories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace jobApplication.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<JobService>();
            builder.Services.AddScoped<IJobRepository, JobRepository>();
            builder.Services.AddScoped<IJobCandidateApplicationRepository, JobCandidateApplicationRepository>();
            builder.Services.AddScoped<IJobCandidateApplicationService,JobCandidateApplicationService>();
            builder.Services.AddScoped< ICandidateRepository,CandidateRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IJwtService, JwtService>();

            builder.Services.AddScoped<IAuthService, AuthService>();

            builder.Services.AddScoped<
                IJobCandidateApplicationRepository,
                JobCandidateApplicationRepository>();
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

            var jwtSettings = builder.Configuration.GetSection("Jwt");

            var key = jwtSettings["Key"];
            if (string.IsNullOrEmpty(key))
            {
                throw new Exception("JWT Key is missing from appsettings.json");
            }

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                    JwtBearerDefaults.AuthenticationScheme;

                options.DefaultChallengeScheme =
                    JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],

                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(key))
                };
            });

            builder.Services.AddAuthorization();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();

            }

            app.UseHttpsRedirection();
            app.UseAuthentication();


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
