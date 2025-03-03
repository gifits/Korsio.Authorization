using FluentValidation;
using Gifits.Korsio.Authentication.Application.Services.Authorization.GetTokenByEmail;
using Gifits.Korsio.Authorization.Application.Services.Authentication.CreateAccountService;
using Gifits.Korsio.Authorization.Application.Services.Authentication.UserLogin;
using Gifits.Korsio.Authorization.Application.Services.Authorization.RefreshToken;
using Gifits.Korsio.Authorization.Application.Services.Authorization.ValidateGoogleToken;
using Gifits.Korsio.Authorization.Application.Services.Password;
using Gifits.Korsio.Authorization.Application.Services.Token.GenerateToken;
using Gifits.Korsio.Authorization.Application.Validators.CreateAccount;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gifits.Korsio.Authorization.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<GetTokenByEmailService>();
            services.AddScoped<GenerateTokenService>();
            services.AddScoped<GenerateRefreshTokenService>();
            services.AddScoped<RefreshTokenService>();
            services.AddScoped<ValidateGoogleTokenService>();
            services.AddScoped<CreateAccountService>();
            services.AddScoped<UserLoginService>();
            services.AddSingleton<PasswordHasher>();

            //validator
            services.AddValidatorsFromAssemblyContaining<CreateAccountValidator>();

            return services;
        }
    }
}