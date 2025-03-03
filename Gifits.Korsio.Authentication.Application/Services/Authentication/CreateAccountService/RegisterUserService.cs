using Gifits.Korsio.Authorization.Application.Contracts.SecurityRepository;
using Gifits.Korsio.Authorization.Application.Contracts.UserRepository;
using Gifits.Korsio.Authorization.Application.Dto.Athentication.RegisterUser;
using Gifits.Korsio.Authorization.Application.Services.Password;
using Gifits.Korsio.Authorization.Domain.Models.Security;
using Gifits.Korsio.Authorization.Domain.Models.User;

namespace Gifits.Korsio.Authorization.Application.Services.Authentication.CreateAccountService
{
    public class RegisterUserService
    {
        private readonly PasswordHasher _passwordHasher;
        private readonly ISecurityRepository _securityRepository;
        public RegisterUserService(PasswordHasher passwordHasher,
            ISecurityRepository securityRepository)
        {
            _passwordHasher = passwordHasher;
            _securityRepository = securityRepository;
        }

        public async Task<bool> RegisterUser(RegisterUserRequest createAccountRequest)
        {
            KtSecurity req = new KtSecurity()
            {
                Email = createAccountRequest.Email,
                PasswordHash = _passwordHasher.Hash(createAccountRequest.Password),
                CreateDate = DateTime.UtcNow
            };

            await _securityRepository.Create(req);

            return true;
        }
    }
}