using ExpenseShare.Application.Dtos;
using ExpenseShare.Application.Interfaces.Services;
using ExpenseShare.Application.Services;
using ExpenseShare.Application.Validators;
using ExpenseShare.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Application
{
    public static class ApplicationServicesRegistration
    {
        private const string altSecret = "Expense Sharing Application's Developer Secret Key. Change in Production.";

        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection("ApiSettings:JwtOptions"));

            //var settingsSection = configuration.GetSection("ApiSettings");

            //var secret = settingsSection.GetValue<string>("Secret") ?? altSecret;
            //var issuer = settingsSection.GetValue<string>("Issuer");
            //var audience = settingsSection.GetValue<string>("Audience");

            //var key = Encoding.ASCII.GetBytes(secret);

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(options =>
            //{
            //    options.RequireHttpsMetadata = false;
            //    options.SaveToken = true;
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = true,
            //        ValidIssuer = issuer,
            //        ValidateAudience = false
            //    };
            //});

            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IUserService, UserService>();

            services.AddSingleton<IValidator<ExpenseDto>, ExpenseDtoValidator>();
            services.AddSingleton<IValidator<GroupCreateDto>, GroupDtoValidator>();

            return services;
        }
    }
}
