using Gifits.Korsio.Authorization.Application.Contracts.RefreshTokenRepository;
using Gifits.Korsio.Authorization.Application.Contracts.UserRepository;
using Gifits.Korsio.Authorization.Application.Dto.Authorization;
using Gifits.Korsio.Authorization.Application.Services.Token.GenerateToken;

namespace Gifits.Korsio.Authentication.Application.Services.Authorization.GetTokenByEmail
{
    public class GetTokenByEmailService
    {
        private readonly IUserRepository _userRepository;
        private readonly GenerateTokenService _generateTokenService;
        private readonly GenerateRefreshTokenService _generateRefreshTokenService;
        public GetTokenByEmailService(IUserRepository userRepository, 
            IRefreshTokenRepository refreshTokenRepository, 
            GenerateTokenService generateTokenService, 
            GenerateRefreshTokenService generateRefreshTokenService)
        {
            _userRepository = userRepository;
            _generateTokenService = generateTokenService;
            _generateRefreshTokenService = generateRefreshTokenService;
        }
        public async Task<GetTokenByEmailDto> GetTokenByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);

            if (user == null)
                throw new UnauthorizedAccessException();

            var token = _generateTokenService.Generate(user);

            var refreshToken = await _generateRefreshTokenService.Generate(user.Id);

            return new GetTokenByEmailDto()
            {
                Token = token,
                RefreshToken = refreshToken
            };
        }
    }
}