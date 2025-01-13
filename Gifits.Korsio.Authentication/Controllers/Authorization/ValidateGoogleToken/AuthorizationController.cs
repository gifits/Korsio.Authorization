using Gifits.Korsio.Authentication.Application.Services.Authorization.GetTokenByEmail;
using Gifits.Korsio.Authorization.Api.Dto.ValidateGoogelToken;
using Gifits.Korsio.Authorization.Application.Services.Authorization.ValidateGoogleToken;
using Microsoft.AspNetCore.Mvc;

namespace Gifits.Korsio.Authorization.Api.Controllers.Authorization.ValidateGoogleToken
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly ValidateGoogleTokenService _validateGoogleTokenService;
        private readonly GetTokenByEmailService _getTokenByEmailService;
        public AuthorizationController(ValidateGoogleTokenService validateGoogleTokenService, 
            GetTokenByEmailService getTokenByEmailService)
        {
            _validateGoogleTokenService = validateGoogleTokenService;
            _getTokenByEmailService = getTokenByEmailService;
        }

        [HttpPost("google")]
        public async Task<IActionResult> GetTokenbyEmail([FromBody] ValidateGoogleTokenRequest req)
        {
            var email = await _validateGoogleTokenService.Validate(req.Token);

            var token = await _getTokenByEmailService.GetTokenByEmail(email);

            var response = new ValidateGoogleTokenResponse();

            response.Map(token);

            return Ok(response);
        }
    }
}
