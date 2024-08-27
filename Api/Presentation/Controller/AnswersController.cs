using Entities.DTOs;
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
        public async Task<IActionResult> AddAnswer([FromQuery] int questionId, [FromQuery] string answerText)
        {
            if (string.IsNullOrEmpty(answerText))
                return BadRequest("Answer text cannot be null or empty.");



            var answerDto = new AnswerDtoForInsert
            {
                QuestionId = questionId,
                Content = answerText
            };

            var createdAnswer = await _manager.AnswerService.CreateAnswerAsync(answerDto);

            return CreatedAtAction(nameof(GetOneAnswerById), new { id = createdAnswer.Id }, createdAnswer);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAnswerById(int id)
        {

            var answer = await _manager.AnswerService.GetOneAnswerByIdAsync(id, false);
            return Ok(answer);

        }
    }
}
