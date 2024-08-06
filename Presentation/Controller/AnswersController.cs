using Entities.Exceptions;
using Entities.Models;
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
    public class AnswersController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public AnswersController(IServiceManager manager)
        {
            _manager = manager;
        }
        [HttpPost("AddAnswer")]
        public IActionResult AddAnswer(int questionId,string answerText)
        {
            var question = _manager.QuestionService.GetOneQuestionById(questionId, true);
            if (question == null) throw new EntityNotFoundException<Question>(questionId);

            var answers = _manager.AnswerService
                .GetAllAnswers(false)
                .Where(b => b.QuestionId == questionId);

            var answer = new Answer()
            {
                AnswerText = answerText,
                CreatedDate = DateTime.Now,
                QuestionId = questionId,
                Question = question
            };
            _manager.AnswerService.CreateAnswer(answer);
            return StatusCode(201,answer);
        }
    }
}
