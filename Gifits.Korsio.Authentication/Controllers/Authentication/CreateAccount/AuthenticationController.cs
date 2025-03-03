using Gifits.Korsio.Authorization.Application.Dto.Athentication.CreateAccount;
using Gifits.Korsio.Authorization.Application.Services.Authentication.CreateAccountService;
using Microsoft.AspNetCore.Mvc;

namespace Gifits.Korsio.Authorization.Api.Controllers.Authentication.CreateAccount
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly CreateAccountService _createAccountService;

        public AuthenticationController(CreateAccountService createAccountService)
        {
            _createAccountService = createAccountService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CrateAccount([FromBody] CreateAccountRequest createAccountRequest)
        {
            var response = await _createAccountService.CreateAccount(createAccountRequest);

            return Ok(response);
        }
    }
}
