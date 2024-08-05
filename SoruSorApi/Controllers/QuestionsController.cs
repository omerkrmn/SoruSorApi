using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoruSorApi.Repositories;
using System.Collections.Generic;

namespace SoruSorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {

        private readonly RepositoryContext _context;

        public QuestionsController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetQuestions()
        {
            return Ok();
        }
        [HttpGet("GetUserQuestions")]
        public IActionResult GetUserQuestions([FromQuery(Name = "userId")] int userId)
        {
            return Ok();


        }
        [HttpPost]
        public IActionResult PostQuestions([FromBody] QuestionDTO questionDTO)
        {
            if (questionDTO == null) return BadRequest("question can not be null");

            var sendUser = _context.Users.Where(u => u.ID == questionDTO.AskingTheUserID).FirstOrDefault();
            var reciveUser = _context.Users.Where(u => u.ID == questionDTO.AskedByUserID).FirstOrDefault();
            if (sendUser == null || reciveUser == null) return BadRequest("user is not found");

            var question = new Question();
            question.QuestionText = questionDTO.QuestionText;
            question.AskedByUser = sendUser;
            question.AskedByUserID = sendUser.ID;
            question.AskingTheUser = reciveUser;
            question.AskingTheUserID = reciveUser.ID;
            question.CreatedDate = DateTime.Now;
            question.Likes = [];

            _context.Questions.Add(question);
            _context.SaveChanges();
            return StatusCode(201);
        }

    }
}
