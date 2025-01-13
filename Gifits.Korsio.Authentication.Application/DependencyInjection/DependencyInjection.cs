using Gifits.Korsio.Authentication.Application.Services.Authorization.GetTokenByEmail;
using Gifits.Korsio.Authorization.Application.Services.Authorization.RefreshToken;
using Gifits.Korsio.Authorization.Application.Services.Authorization.ValidateGoogleToken;
using Gifits.Korsio.Authorization.Application.Services.Token.GenerateToken;
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

            return services;
        }
    }
}