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

        public async Task<IEnumerable<AnswerDto>> GetAllAnswersAsync(bool trackChanges)
        {
            var answers = await _manager.Answer.GetAllAnswersAsync(trackChanges);
            return _mapper.Map<IEnumerable<AnswerDto>>(answers);
        }

        public async Task<AnswerDto> GetOneAnswerByIdAsync(int id, bool trackChanges)
        {
            var answer = await _manager.Answer.GetOneAnswerByIdAsync(id, trackChanges);
            if (answer == null) throw new EntityNotFoundException<Answer>(id);
            return _mapper.Map<AnswerDto>(answer);
        }

        public async Task<AnswerDto> CreateAnswerAsync(AnswerDtoForInsert answerDto)
        {
            if (answerDto == null) throw new ArgumentNullException(nameof(answerDto));

            var answer = _mapper.Map<Answer>(answerDto);
            _manager.Answer.CreateOneAnswer(answer);
            await _manager.SaveAsync();

            return _mapper.Map<AnswerDto>(answer);
        }

        public async Task UpdateOneAnswerAsync(AnswerDto answerDto, bool trackChanges)
        {
            if (answerDto == null) throw new ArgumentNullException(nameof(answerDto));

            var entity = await _manager.Answer.GetOneAnswerByIdAsync(answerDto.Id, trackChanges);
            if (entity == null) throw new EntityNotFoundException<Answer>(answerDto.Id);

            _mapper.Map(answerDto, entity);

            _manager.Answer.UpdateOneAnswer(entity);
            await _manager.SaveAsync();
        }

        public async Task DeleteOneAnswerAsync(int id, bool trackChanges)
        {
            var entity = await _manager.Answer.GetOneAnswerByIdAsync(id, trackChanges);
            if (entity == null) throw new EntityNotFoundException<Answer>(id);

            _manager.Answer.DeleteOneAnswer(entity);
            await _manager.SaveAsync();
        }
    }
}
