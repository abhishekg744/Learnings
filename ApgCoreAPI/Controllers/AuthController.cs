using System.Threading.Tasks;
using ApgCoreAPI.Data;
using ApgCoreAPI.Dtos.User;
using ApgCoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApgCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto user)
        {
            ServiceResponse<string> response = await _authRepository.Login(user.Username, user.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto user)
        {
            ServiceResponse<int> response = await _authRepository.Register(new User { Username = user.Username }, user.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


    }
}