using AutoMapper;
using Entities.DTOs;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EntityManager
{
    public class QuestionManager : IQuestionService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public QuestionManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public  Question CreateOneQuestion(QuestionDTO questionDto)
        {
            if (questionDto == null)
                throw new ArgumentNullException(nameof(questionDto), "QuestionDTO cannot be null.");

            
            var question = _mapper.Map<Question>(questionDto);

            _manager.Question.CreateOneQuestion(question);
             _manager.Save(); // Asenkron save metodu
            return question;
        }

        public void DeleteOneQuestion(int id, bool trackChanges)
        {
            var question = _manager.Question.GetOneQuestionById(id, trackChanges);
            if (question is null) throw new EntityNotFoundException<Question>(id);
            _manager.Question.DeleteOneQuestion(question);
            _manager.Save();
        }

        public IEnumerable<Question> GetAllQuestions(bool trackChanges)
        {
            var questions = _manager.Question.GetAllQuestions(trackChanges);
            return questions;
        }

        public Question GetOneQuestionById(int id, bool trackChanges)
        {
            var question = _manager.Question.GetOneQuestionById(id, trackChanges);
            if (question is null) throw new EntityNotFoundException<Question>(id);
            return question;
        }


    }
}
