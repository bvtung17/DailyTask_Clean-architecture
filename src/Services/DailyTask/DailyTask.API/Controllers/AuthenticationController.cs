using DailyTask.Application.Dtos;
using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Requests;

namespace DailyTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpGet]
        public async Task<IActionResult> Login(LoginUserRequest request)
        {
            var result = await _authenticationService.AuthenticateAsync(request);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            var result = await _authenticationService.Register(userDto);
            return Ok(result);
        }
    }
}
