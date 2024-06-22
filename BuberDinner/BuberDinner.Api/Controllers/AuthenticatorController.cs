using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticatorController : ControllerBase
    {
        [HttpPost("register")]

        public IActionResult Register(RegisterRequest request)
        {
            return Ok(request);
        }

        [HttpPost("login")]

        public IActionResult Login(LoginRequest request)
        {
            return Ok(request);
        }
    }
}
