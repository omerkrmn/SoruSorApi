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

        [HttpGet("{id:int}")]
        public IActionResult GetOneUser([FromRoute] int id)
        {
            var user = _manager.UserService.GetOneUserById(id, false);
            var userWithQuestions = _manager.UserService.GetOneUserWithQuestions(id, false);
            var questions=_manager.QuestionService.GetOneQuestionById(id, false);   

            return Ok(user);
        }
        [HttpPost]
        public IActionResult PostOneUser([FromBody] CreateForUserDTO user)
        {
            
            _manager.UserService.CreateOneUser(user);
            return Ok();    
        }

    }
}
