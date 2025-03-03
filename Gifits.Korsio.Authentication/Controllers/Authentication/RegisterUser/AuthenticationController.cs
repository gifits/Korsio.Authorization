using Gifits.Korsio.Authorization.Application.Dto.Athentication.RegisterUser;
using Gifits.Korsio.Authorization.Application.Services.Authentication.CreateAccountService;
using Microsoft.AspNetCore.Mvc;

namespace Gifits.Korsio.Authorization.Api.Controllers.Authentication.RegisterUser
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly RegisterUserService _registerUserService;

        public AuthenticationController(RegisterUserService createAccountService)
        {
            _registerUserService = createAccountService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CrateAccount([FromBody] RegisterUserRequest createAccountRequest)
        {
            var response = await _registerUserService.RegisterUser(createAccountRequest);

            return Ok(response);
        }
    }
}
