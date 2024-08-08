using AutoMapper;
using Entities.DTOs;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<AnswerDto> GetAllAnswers(bool trackChanges)
        {
            var answers = _manager.Answer.GetAllAnswers(trackChanges);
            return _mapper.Map<IEnumerable<AnswerDto>>(answers);
        }

        public AnswerDto GetOneAnswerById(int id, bool trackChanges)
        {
            var answer = _manager.Answer.GetOneAnswerById(id, trackChanges);
            if (answer == null) throw new EntityNotFoundException<Answer>(id);
            return _mapper.Map<AnswerDto>(answer);
        }

        public AnswerDto CreateAnswer(AnswerDtoForInsert answerDto)
        {
            if (answerDto == null) throw new ArgumentNullException(nameof(answerDto));

            var answer = _mapper.Map<Answer>(answerDto);
            _manager.Answer.CreateOneAnswer(answer);
            _manager.Save();

            return _mapper.Map<AnswerDto>(answer);
        }

        public void UpdateOneAnswer(AnswerDto answerDto, bool trackChanges)
        {
            if (answerDto == null) throw new ArgumentNullException(nameof(answerDto));

            var entity = _manager.Answer.GetOneAnswerById(answerDto.Id, trackChanges);
            if (entity == null) throw new EntityNotFoundException<Answer>(answerDto.Id);

            _mapper.Map(answerDto, entity);

            _manager.Answer.UpdateOneAnswer(entity);
            _manager.Save();
        }

        public void DeleteOneAnswer(int id, bool trackChanges)
        {
            var entity = _manager.Answer.GetOneAnswerById(id, trackChanges);
            if (entity == null) throw new EntityNotFoundException<Answer>(id);

            _manager.Answer.DeleteOneAnswer(entity);
            _manager.Save();
        }
    }
}
