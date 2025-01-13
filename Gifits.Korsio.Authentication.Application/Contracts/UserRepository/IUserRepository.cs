using Gifits.Korsio.Authorization.Domain.Models.User;

namespace Gifits.Korsio.Authorization.Application.Contracts.UserRepository
{
    public interface IUserRepository
    {
        Task<KtUser> GetByEmail(string email);
        Task<KtUser> GetUserById(int userId);
    }
}
