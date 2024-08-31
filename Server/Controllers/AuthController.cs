using Microsoft.AspNetCore.Mvc;
using MyApp.Services;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var (isSuccess, token, message) = await _authService.LoginAsync(loginModel);
            if (isSuccess)
                return Ok(new { Token = token });
            return Unauthorized(new { Message = message });
        }
    }
}