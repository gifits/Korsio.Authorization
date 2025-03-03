using Gifits.Korsio.Authorization.Application.Contracts.UserRepository;
using Gifits.Korsio.Authorization.Application.Dto.Athentication.CreateAccount;
using Gifits.Korsio.Authorization.Application.Services.Password;
using Gifits.Korsio.Authorization.Domain.Models.User;

namespace Gifits.Korsio.Authorization.Application.Services.Authentication.CreateAccountService
{
    public class CreateAccountService
    {
        private readonly PasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        public CreateAccountService(PasswordHasher passwordHasher, 
            IUserRepository userRepository)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
        }

        public async Task<bool> CreateAccount(CreateAccountRequest createAccountRequest)
        {
            KtUser req = new KtUser()
            {
                Name = createAccountRequest.Name,
                Email = createAccountRequest.Email,
                LastName = createAccountRequest.LastName,
                PasswordHash = _passwordHasher.Hash(createAccountRequest.Password),
                CreateDate = DateTime.UtcNow
            };

            await _userRepository.Create(req);

            return true;
        }
    }
}