using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [HttpPost(Name = "AddQuestion")]
        public async Task<IActionResult> AddQuestion([FromBody] QuestionDtoForInsert questionDto)
        {
            var question = await _manager.QuestionService.CreateOneQuestionAsync(questionDto);
            return StatusCode(201, question);
        }
        // pagination 
        [Authorize]
        [HttpGet("user/{userId}/with-likes")]
        public async Task<IActionResult> GetAllQuestionsByUserWithLikesAndAnswer([FromRoute] int userId)
        {
            var questionsDetailsDto = await _manager.QuestionService.GetAllQuestionWithUserIdAsync(userId);
            return Ok(questionsDetailsDto);
        }

    }
}
