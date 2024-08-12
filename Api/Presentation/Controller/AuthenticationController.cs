using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
namespace Presentation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AuthenticationController(IServiceManager service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegisterDTO registerDTO)
        {
            if (registerDTO == null) return BadRequest();
            var result = await _service.AuthenticationService.RegisterUser(registerDTO);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return Ok(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForAuthenticationDTO user)
        {
            if (!await _service.AuthenticationService.ValidateUser(user))
                return Unauthorized();
            return Ok(
                new
                {
                    Token = await _service.AuthenticationService.CreateToken()
                }
                );
        }
    }

}



