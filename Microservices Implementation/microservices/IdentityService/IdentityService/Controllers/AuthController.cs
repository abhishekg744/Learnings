using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityService.Entities;
using IdentityService.Model;
using IdentityService.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IdentityService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authRepository)
        {
            _authService = authRepository;

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto user)
        {
            ServiceResponse<string> response = await _authService.Login(user.Username, user.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto user)
        {
            ServiceResponse<int> response = await _authService.Register(new Users { Username = user.Username }, user.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


    }
}
