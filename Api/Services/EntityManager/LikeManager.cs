using AutoMapper;
using Entities.DTOs;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;

namespace Services.EntityManager
{
    public class LikeManager : ILikeService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public LikeManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LikeDto>> GetAllLikesAsync(bool trackChanges)
        {
            var likes = await _manager.Like.GetAllLikesAsync(trackChanges);
            return _mapper.Map<IEnumerable<LikeDto>>(likes);
        }

        public async Task<LikeDto> GetOneLikeByIdAsync(int id, bool trackChanges)
        {
            var like = await _manager.Like.GetOneLikeByIdAsync(id, trackChanges);
            if (like == null) throw new EntityNotFoundException<Like>(id);
            return _mapper.Map<LikeDto>(like);
        }

        public async Task<LikeDto> CreateOneLikeAsync(LikeDtoForInsert likeInsertDto)
        {
            if (likeInsertDto == null)
                throw new ArgumentNullException(nameof(likeInsertDto));

            var likes = await _manager.Like.GetAllLikesAsync(false);
            var existingLike = likes
            .FirstOrDefault(l => l.UserId == likeInsertDto.UserId && l.QuestionId == likeInsertDto.QuestionId);


            if (existingLike != null)
                throw new InvalidOperationException("The user has already liked this question.");

            var like = _mapper.Map<Like>(likeInsertDto);
            _manager.Like.CreateOneLike(like);
            await _manager.SaveAsync();

            return _mapper.Map<LikeDto>(like);
        }

        public async Task UpdateOneLikeAsync(int id, LikeDto likeDto, bool trackChanges)
        {
            if (likeDto == null) throw new ArgumentNullException(nameof(likeDto));

            var entity = await _manager.Like.GetOneLikeByIdAsync(id, trackChanges);
            if (entity == null) throw new EntityNotFoundException<Like>(id);

            _mapper.Map(likeDto, entity);

            _manager.Like.UpdateOneLike(entity);
            await _manager.SaveAsync();
        }

        public async Task DeleteOneLikeAsync(int userId, int questionId, bool trackChanges)
        {
            var likes = await _manager.Like.GetAllLikesAsync(false);
            var like = likes.Where(x => x.QuestionId == questionId && x.UserId == userId)
                    .SingleOrDefault();
            if (like == null) throw new ArgumentNullException(nameof(like));

            _manager.Like.DeleteOneLike(like);
            await _manager.SaveAsync();
        }


    }
}
