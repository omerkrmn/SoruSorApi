using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

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
        public IActionResult AddQuestion([FromBody] QuestionDtoForInsert questionDto)
        {
            var question = _manager.QuestionService.CreateOneQuestion(questionDto);
            return StatusCode(201, question);
        }

        [HttpGet("user/{userId}/with-likes")]
        public IActionResult GetAllQuestionsByUserWithLikesAndAnswer([FromRoute] int userId)
        {
            var questionsDetailsDto = _manager.QuestionService.GetAllQuestionWithUserId(userId);
            return Ok(questionsDetailsDto);
        }
    }
}
