using Gifits.Korsio.Authentication.Application.Services.Authorization.GetTokenByEmail;
using Gifits.Korsio.Authorization.Api.Dto.GetTokenByEmail;
using Microsoft.AspNetCore.Mvc;

namespace Gifits.Korsio.Authorization.Controllers.Authentication.GetTokenByEmail
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly GetTokenByEmailService _getTokenByEmailService;
        public AuthorizationController(GetTokenByEmailService getTokenByEmailService)
        {
            _getTokenByEmailService = getTokenByEmailService;
        }

        [HttpPost("by-email")]
        public async Task<IActionResult> GetTokenbyEmail([FromBody] GetTokenByEmailRequest req)
        {
            var token = await _getTokenByEmailService.GetTokenByEmail(req.email);

            var response = new GetTokenByEmailResponse();

            response.Map(token);

            return Ok(response);
        }
    }
}