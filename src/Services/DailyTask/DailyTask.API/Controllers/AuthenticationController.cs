using DailyTask.Application.Contracts.Core.Interfaces;
using DailyTask.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Login(string userName, string password)
        {
            var result = await _authenticationService.AuthenticateAsync(userName, password);
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
