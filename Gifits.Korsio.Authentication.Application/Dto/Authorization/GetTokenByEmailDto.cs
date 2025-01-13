namespace Gifits.Korsio.Authorization.Application.Dto.Authorization
{
    public class GetTokenByEmailDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
