using AutoMapper;
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
    public class AnswerManager : IAnswerService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public AnswerManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
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
            if (entity == null) throw new EntityNotFoundException<Answer>(id);
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
            var answer =  _manager.Answer.GetOneAnswerById(id, trackChanges);
            if (answer == null) throw new EntityNotFoundException<Answer>(id);
            return answer;
        }

        public void UpdateOneAnswer(int id, Answer answer, bool trackChanges)
        {
            if(answer == null) throw new ArgumentNullException(nameof(answer));
            var entity = _manager.Answer.GetOneAnswerById(id, trackChanges);
            if (entity == null) throw new EntityNotFoundException<User>(id);

            entity.AnswerText = answer.AnswerText;

            _manager.Answer.UpdateOneAnswer(entity);
            _manager.Save();
        }
    }
}
