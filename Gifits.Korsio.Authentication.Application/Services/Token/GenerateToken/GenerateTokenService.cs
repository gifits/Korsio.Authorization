using Gifits.Korsio.Authorization.Domain.Models.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gifits.Korsio.Authorization.Application.Services.Token.GenerateToken
{
    public class GenerateTokenService
    {
        private readonly IConfiguration _configuration;
        public GenerateTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Generate(KtUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("TokenConfiguration:SecretKey").Value);
            var expirationMinutes = int.Parse(_configuration.GetSection("TokenConfiguration:ExpirationMinutes").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, $"{user.Name} {user.LastName}"),
                new Claim(ClaimTypes.Email, user.Email)
                }),

                //Expiration Time
                Expires = DateTime.UtcNow.AddMinutes(expirationMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = "Jwt:Issuer",
                Issuer = "Jwt:Issuer"
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}