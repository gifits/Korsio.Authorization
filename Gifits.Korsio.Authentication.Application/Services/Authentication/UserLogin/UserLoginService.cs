using Gifits.Korsio.Authorization.Application.Contracts.UserRepository;
using Gifits.Korsio.Authorization.Application.Dto.Athentication.UserLogin;
using Gifits.Korsio.Authorization.Application.Services.Password;
using Gifits.Korsio.Authorization.Application.Services.Token.GenerateToken;

namespace Gifits.Korsio.Authorization.Application.Services.Authentication.UserLogin
{
    public class UserLoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher _passwordHasher;
        private readonly GenerateTokenService _generateTokenService;
        private readonly GenerateRefreshTokenService _generateRefreshTokenService;
        public UserLoginService(PasswordHasher passwordHasher, 
            IUserRepository userRepository, 
            GenerateTokenService generateTokenService, 
            GenerateRefreshTokenService generateRefreshTokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _generateTokenService = generateTokenService;
            _generateRefreshTokenService = generateRefreshTokenService;
        }

        public async Task<UserLoginResponse> Login(UserLoginRequest userLogin)
        {
            var entity = await _userRepository.GetByEmail(userLogin.Email);

            if (entity == null)
            {
                throw new DirectoryNotFoundException(userLogin.Email);
            }

            var verify = _passwordHasher.Verify(userLogin.Password, entity.PasswordHash);

            if(!verify)
            {
                throw new Exception("Wrong password");
            }

            var token = _generateTokenService.Generate(entity);

            var refreshToken = await _generateRefreshTokenService.Generate(entity.Id);

            return new UserLoginResponse()
            {
                Token = token,
                RefreshToken = refreshToken
            };
        }
    }
}