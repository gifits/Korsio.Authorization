using Gifits.Korsio.Authorization.Application.Contracts.RefreshTokenRepository;
using Gifits.Korsio.Authorization.Application.Dto.Authorization;
using Gifits.Korsio.Authorization.Application.Services.Token.GenerateToken;

namespace Gifits.Korsio.Authorization.Application.Services.Authorization.RefreshToken
{
    public class RefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly GenerateTokenService _generateTokenService;
        private readonly GenerateRefreshTokenService _generateRefreshTokenService;

        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository,
            GenerateTokenService generateTokenService,
            GenerateRefreshTokenService generateRefreshTokenService)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _generateTokenService = generateTokenService;
            _generateRefreshTokenService = generateRefreshTokenService;
        }

        public async Task<GetTokenByEmailDto> RefreshToken(string token)
        {
            var currentToken = await _refreshTokenRepository.GetCurrentToken(token);

            if (currentToken == null)
                throw new ArgumentException("No token to refresh");

            if (currentToken.ExpiresOnUtc < DateTime.UtcNow)
                throw new Exception("Token expired");

            var newToken = _generateTokenService.Generate(currentToken.User);

            var refreshToken = await _generateRefreshTokenService.Generate(currentToken.UserId);

            return new GetTokenByEmailDto()
            {
                Token = newToken,
                RefreshToken = refreshToken
            };
        }
    }
}
