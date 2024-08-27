using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _service;

        public UserController(IServiceManager manager)
        {
            _service = manager;
        }


        [HttpGet("/{nickName}")]
        public async Task<IActionResult> SearchUsers([FromQuery] string nickName)
        {
            if (string.IsNullOrWhiteSpace(nickName))
                return BadRequest("Nickname is required.");
            var users = await _service.UserService.SearchUserAsync(nickName);

            if (users == null || !users.Any())
                return NotFound("No users found with the given nickname.");


            return Ok(users);
        }

    }
}
