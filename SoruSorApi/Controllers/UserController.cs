using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoruSorApi.Repositories;

namespace SoruSorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // get user by ID
        // Search user with name field or surname field

        //basic delete user 
        // basic update user

        private readonly RepositoryContext _context;

        public UserController(RepositoryContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetUsers() { 
            var users = _context.Users.ToList();
            return Ok(users);
        }
        [HttpPost]
        public IActionResult AddUser([FromBody] UserDTO userDto) {
            if (userDto == null) return BadRequest("user can not be null");
            var user = new User();
            user.Age = userDto.Age;
            user.Email = userDto.Email;
            user.PhoneNumber = userDto.PhoneNumber;
            user.ProfilePictureUrl = userDto.ProfilePictureUrl;
            user.Password = userDto.Password;
            user.Name = userDto.Name;

            user.CreatedDate= DateTime.Now;
            user.Questions = [];
            _context.Users.Add(user);
            _context.SaveChanges();
            return StatusCode(201,user);

        }
    }
}
