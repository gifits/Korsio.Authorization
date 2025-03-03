using Gifits.Korsio.Authorization.Application.Contracts.RefreshTokenRepository;
using Gifits.Korsio.Authorization.Application.Dto.Athentication.Logout;

namespace Gifits.Korsio.Authorization.Application.Services.Authentication.Logout
{
    public class UserLogoutService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        public UserLogoutService(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<bool> Logout(UserLogoutRequest req)
        {
            var entity = await _refreshTokenRepository.GetCurrentByUserId(req.UserId);

            if(entity != null)
            {
                entity.ExpiresOnUtc = DateTime.UtcNow;
            }

            entity = await _refreshTokenRepository.Update(entity);

            return entity != null;
        }
    }
}
