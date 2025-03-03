using Gifits.Korsio.Authorization.Application.Dto.Athentication.Logout;
using Gifits.Korsio.Authorization.Application.Services.Authentication.Logout;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gifits.Korsio.Authorization.Api.Controllers.Authentication.Logout
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserLogoutService _logoutService;
        public AuthenticationController(UserLogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] UserLogoutRequest loginRequest)
        {
            var response = await _logoutService.Logout(loginRequest);

            return Ok(response);
        }
    }
}