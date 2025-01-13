using Gifits.Korsio.Authorization.Api.Dto.RefreshToken;
using Gifits.Korsio.Authorization.Application.Services.Authorization.RefreshToken;
using Microsoft.AspNetCore.Mvc;

namespace Gifits.Korsio.Authorization.Api.Controllers.Authorization.RefreshToken
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly RefreshTokenService _refreshTokenService;
        public AuthorizationController(RefreshTokenService refreshTokenService)
        {
            _refreshTokenService = refreshTokenService;
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest refreshTokenRequest)
        {
            var response = await _refreshTokenService.RefreshToken(refreshTokenRequest.RefreshToken);

            return Ok(response);
        }
    }
}
