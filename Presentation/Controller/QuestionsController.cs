using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.EFCore;
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
    public class QuestionsController : ControllerBase
    {

        private readonly IServiceManager _manager;

        public QuestionsController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpPost("AddQuestion")]
        public IActionResult AddQuestion([FromBody] QuestionDTO questionDto)
        {
            if (questionDto == null)
                return BadRequest("Question data is null.");
            _manager.QuestionService.CreateOneQuestion(questionDto);
            return Ok(questionDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuestion([FromRoute] int id)
        {
            return Ok();
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetAllQuestionsByUser([FromRoute] int userId)
        {
            return Ok();
        }

        [HttpGet("user/{userId}/with-likes")]
        public IActionResult GetAllQuestionsByUserWithLikes([FromRoute] int userId)
        {
            return Ok();
        }

        [HttpGet("{id}/user")]
        public IActionResult GetOneQuestionWithUserId([FromRoute] int id)
        {
            return Ok();
        }


    }
}
