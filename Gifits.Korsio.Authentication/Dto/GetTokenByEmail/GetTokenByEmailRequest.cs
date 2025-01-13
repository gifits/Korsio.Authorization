using System.ComponentModel.DataAnnotations;

namespace Gifits.Korsio.Authorization.Api.Dto.GetTokenByEmail
{
    public class GetTokenByEmailRequest
    {
        [Required]
        public string email { get; set; }
    }
}
