using Gifits.Korsio.Authorization.Application.Dto.Athentication.CreateAccount;
using Gifits.Korsio.Authorization.Domain.Models.User;

namespace Gifits.Korsio.Authorization.Application.Contracts.UserRepository
{
    public interface IUserRepository
    {
        Task<KtUser> Create(KtUser user);
        Task<KtUser> GetByEmail(string email);
        Task<KtUser> GetUserById(int userId);
        Task<bool> UserEmailExists(string email);
    }
}
