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

        public QuestionManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public Question CreateOneQuestion(Question question)
        {
            if (question == null) throw new ArgumentNullException(nameof(question));
            _manager.Question.CreateOneQuestion(question);
            _manager.Save();
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

        /* 
        An update here might be considered.
        Normally, I don't want questions to be updated, but I will think about it.
        Maybe updates could be allowed in these cases:
        if the question hasn't received an answer yet or if less than 5 minutes have passed since the question was asked.
        */


    }
}
