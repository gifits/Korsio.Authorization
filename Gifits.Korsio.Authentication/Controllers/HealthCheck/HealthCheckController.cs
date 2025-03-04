using Microsoft.AspNetCore.Mvc;

namespace Gifits.Korsio.Authorization.Api.Controllers.HealthCheck
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthCheckController : ControllerBase
    {

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("pong");
        }
    }
}