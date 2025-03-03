using Gifits.Korsio.Authorization.Application.Dto.Athentication.UserLogin;
using Gifits.Korsio.Authorization.Application.Services.Authentication.UserLogin;
using Gifits.Korsio.Authorization.Application.Services.Password;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Gifits.Korsio.Authorization.Api.Controllers.Authentication.Login
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserLoginService _loginService;
        public AuthenticationController(UserLoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest loginRequest)
        {
            var response = await _loginService.Login(loginRequest);

            return Ok(response);
        }

    }
}
