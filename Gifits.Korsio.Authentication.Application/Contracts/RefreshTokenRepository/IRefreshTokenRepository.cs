using Gifits.Korsio.Authorization.Domain.Models.Authorization;

namespace Gifits.Korsio.Authorization.Application.Contracts.RefreshTokenRepository
{
    public interface IRefreshTokenRepository
    {
        Task<KtRefreshToken> Create(KtRefreshToken refreshToken);
        Task<KtRefreshToken> GetCurrentToken(string token);
    }
}
