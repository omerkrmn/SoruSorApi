using Entities.DTOs;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var users = _manager.UserService.GetAllUsers(false); // veya true, trackChanges ihtiyacınıza göre
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneUser([FromRoute]int id)
        {
            var user = _manager.UserService.GetOneUserById(id, false);
            return Ok(user);
        }
        [HttpPost]
        public IActionResult PostOneUser([FromBody] UserDTO userDTO)
        {
            var userDto = _manager.UserService.CreateOneUser(userDTO);
            return StatusCode(201,userDto);    
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _manager.UserService.DeleteOneUser(id, true);
            return NoContent();
        }

    }
}
