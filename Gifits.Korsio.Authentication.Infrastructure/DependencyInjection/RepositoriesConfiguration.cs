using Gifits.Korsio.Authorization.Application.Contracts.RefreshTokenRepository;
using Gifits.Korsio.Authorization.Application.Contracts.UserRepository;
using Gifits.Korsio.Authorization.Infrastructure.Repositories.RefreshTokenRepository;
using Gifits.Korsio.Authorization.Infrastructure.Repositories.UserRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gifits.Korsio.Authorization.Infrastructure.DependencyInjection
{
    public static class RepositoriesConfiguration
    {
        public static IServiceCollection AddRepositoryConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            return services;
        }
    }
}