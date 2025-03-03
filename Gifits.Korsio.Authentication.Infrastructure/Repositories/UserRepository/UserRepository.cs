using Gifits.Korsio.Authorization.Application.Contracts.UserRepository;
using Gifits.Korsio.Authorization.Domain.Models.User;
using Gifits.Korsio.Authorization.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Gifits.Korsio.Authorization.Infrastructure.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly KorsioDbContext _korsioDbContext;
        public UserRepository(KorsioDbContext korsioDbContext)
        {
            _korsioDbContext = korsioDbContext;
        }

        public async Task<KtUser> Create(KtUser user)
        {
            try
            {
                _korsioDbContext.Users.Add(user);
                await _korsioDbContext.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<KtUser> GetByEmail(string email)
        {
            try
            {
                return await _korsioDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<KtUser> GetUserById(int userId)
        {
            try
            {
                return await _korsioDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> UserEmailExists(string email)
        {
            try
            {
                return await _korsioDbContext.Users.AnyAsync(u => u.Email == email);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}