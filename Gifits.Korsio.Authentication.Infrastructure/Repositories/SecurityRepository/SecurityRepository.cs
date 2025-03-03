using Gifits.Korsio.Authorization.Application.Contracts.SecurityRepository;
using Gifits.Korsio.Authorization.Domain.Models.Security;
using Gifits.Korsio.Authorization.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Gifits.Korsio.Authorization.Infrastructure.Repositories.SecurityRepository
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly KorsioDbContext _korsioDbContext;
        public SecurityRepository(KorsioDbContext korsioDbContext)
        {
            _korsioDbContext = korsioDbContext;
        }

        public async Task<KtSecurity> Create(KtSecurity security)
        {
            try
            {
                _korsioDbContext.Securities.Add(security);
                await _korsioDbContext.SaveChangesAsync();
                return security;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<KtSecurity> GetByEmail(string email)
        {
            try
            {
                return await _korsioDbContext.Securities.FirstOrDefaultAsync(x => x.Email == email);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
