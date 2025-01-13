using Gifits.Korsio.Authorization.Application.Contracts.RefreshTokenRepository;
using Gifits.Korsio.Authorization.Domain.Models.Authorization;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;

namespace Gifits.Korsio.Authorization.Application.Services.Token.GenerateToken
{
    public class GenerateRefreshTokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        public GenerateRefreshTokenService(IConfiguration configuration, IRefreshTokenRepository refreshTokenRepository)
        {
            _configuration = configuration;
            _refreshTokenRepository = refreshTokenRepository;
        }
        public async Task<string> Generate(int userId)
        {
            var expirationDays = int.Parse(_configuration.GetSection("TokenConfiguration:ExpirationDays").Value);

            var refreshToken = new KtRefreshToken()
            {
                UserId = userId,
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32)),
                ExpiresOnUtc = DateTime.UtcNow.AddDays(expirationDays)
            };

            await _refreshTokenRepository.Create(refreshToken);

            return refreshToken.Token;
        }
    }
}