using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly IServiceManager _manager;

        public UserController(IServiceManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers() {
            var users =await _manager.UserService.GetAllUsersAsync(false); 
            return  Ok(users);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneUser([FromRoute]int id)
        {
            var user = await _manager.UserService.GetOneUserByIdAsync(id, false);
            return Ok(user);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("CreateOneUser")]
        public async Task<IActionResult> CreateOneUser([FromBody()] UserDtoForInsert UserDtoForInsert)
        {
            var user = await _manager.UserService.CreateOneUserAsync(UserDtoForInsert);
            return StatusCode(201,user);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(UserDto userDto)
        {
            await _manager.UserService.DeleteOneUserAsync(userDto, true);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody]UserDto userDto) 
        {
            var user = await _manager.UserService.UpdateOneUserAsync(userDto, true);
            return Ok(user);
        }
    }
}
