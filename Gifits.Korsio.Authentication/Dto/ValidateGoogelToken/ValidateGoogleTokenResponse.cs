using Gifits.Korsio.Authorization.Application.Dto.Authorization;

namespace Gifits.Korsio.Authorization.Api.Dto.ValidateGoogelToken
{
    public class ValidateGoogleTokenResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }

        public void Map(GetTokenByEmailDto getTokenByEmailDto)
        {
            Token = getTokenByEmailDto.Token;
            RefreshToken = getTokenByEmailDto.RefreshToken;
        }
    }
}
