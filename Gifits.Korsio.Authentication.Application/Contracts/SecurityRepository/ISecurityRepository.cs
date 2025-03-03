using Gifits.Korsio.Authorization.Domain.Models.Security;

namespace Gifits.Korsio.Authorization.Application.Contracts.SecurityRepository
{
    public interface ISecurityRepository
    {
        Task<KtSecurity> Create(KtSecurity security);
        Task<KtSecurity> GetByEmail(string email);
    }
}