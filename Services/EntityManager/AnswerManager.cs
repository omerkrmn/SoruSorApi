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
    public class AnswerManager : IAnswerService
    {
        private readonly IRepositoryManager _manager;

        public AnswerManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public Answer CreateAnswer(Answer answer)
        {
            if (answer == null) throw new ArgumentNullException(nameof(answer));
            _manager.Answer.CreateOneAnswer(answer);
            _manager.Save();
            return answer;
        }

        public void DeleteOneAnswer(int id, bool trackChanges)
        {
            var entity = _manager.Answer.GetOneAnswerById(id, trackChanges);
            if (entity == null) throw new Exception("Answer is not found!");
            _manager.Answer.DeleteOneAnswer(entity);
            _manager.Save();
        }

        public IEnumerable<Answer> GetAllAnswers(bool trackChanges)
        {
            var answers = _manager.Answer.GetAllAnswers(trackChanges);
            return answers;
        }

        public Answer GetOneAnswerById(int id, bool trackChanges)
        {
            return _manager.Answer.GetOneAnswerById(id, trackChanges);
        }

        public void UpdateOneAnswer(int id, Answer answer, bool trackChanges)
        {
            var entity = _manager.Answer.GetOneAnswerById(id, trackChanges);
            if (entity == null) throw new Exception("not found");
            entity.AnswerText = answer.AnswerText;

            _manager.Answer.UpdateOneAnswer(entity);
            _manager.Save();
        }
    }
}
