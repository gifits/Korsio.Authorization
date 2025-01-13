using System.ComponentModel.DataAnnotations;

namespace Gifits.Korsio.Authorization.Api.Dto.RefreshToken
{
    public class RefreshTokenRequest
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
