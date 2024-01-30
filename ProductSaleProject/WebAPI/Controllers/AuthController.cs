using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginDto userLoginDto)
        {
            var userToLogin = await _authService.Login(userLoginDto);
            if(!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }
            var result = await _authService.CreateAccessToken(userToLogin.Data);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register(UserRegisterDto userRegisterDto)
        {
            var userExists = await _authService.UserExists(userRegisterDto.Email);
            if(!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
            var registerUserResult = await _authService.Register(userRegisterDto);
            var result = await _authService.CreateAccessToken(registerUserResult.Data);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
