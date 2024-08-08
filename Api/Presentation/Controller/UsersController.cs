using Entities.DTOs;
using Entities.Models;
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
        public IActionResult GetAllUsers() {
            var users = _manager.UserService.GetAllUsers(false); 
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneUser([FromRoute]int id)
        {
            var user = _manager.UserService.GetOneUserById(id, false);
            return Ok(user);
        }
        [HttpPost("CreateOneUser")]
        public IActionResult CreateOneUser([FromBody()] UserDtoForInsert UserDtoForInsert)
        {
            var user = _manager.UserService.CreateOneUser(UserDtoForInsert);
            return StatusCode(201,user);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(UserDto userDto)
        {
            _manager.UserService.DeleteOneUser(userDto, true);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody]UserDto userDto) 
        {
            var user = _manager.UserService.UpdateOneUser(userDto,true);
            return Ok(user);
        }
    }
}
