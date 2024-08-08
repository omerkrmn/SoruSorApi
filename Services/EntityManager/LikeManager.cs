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

        public IEnumerable<LikeDto> GetAllLikes(bool trackChanges)
        {
            var likes = _manager.Like.GetAllLikes(trackChanges);
            return _mapper.Map<IEnumerable<LikeDto>>(likes);
        }

        public LikeDto GetOneLikeById(int id, bool trackChanges)
        {
            var like = _manager.Like.GetOneLikeById(id, trackChanges);
            if (like == null) throw new EntityNotFoundException<Like>(id);
            return _mapper.Map<LikeDto>(like);
        }

        public LikeDto CreateOneLike(LikeDtoForInsert likeInsertDto)
        {
            if (likeInsertDto == null)
                throw new ArgumentNullException(nameof(likeInsertDto));
            var existingLike = _manager.Like.GetAllLikes(false)
                .FirstOrDefault(l => l.UserId == likeInsertDto.UserId && l.QuestionId == likeInsertDto.QuestionId);
            if (existingLike != null)
                throw new InvalidOperationException("The user has already liked this question.");

            var like = _mapper.Map<Like>(likeInsertDto);
            _manager.Like.CreateOneLike(like);
            _manager.Save();

            return _mapper.Map<LikeDto>(like);
        }

        public void UpdateOneLike(int id, LikeDto likeDto, bool trackChanges)
        {
            if (likeDto == null) throw new ArgumentNullException(nameof(likeDto));

            var entity = _manager.Like.GetOneLikeById(id, trackChanges);
            if (entity == null) throw new EntityNotFoundException<Like>(id);

            _mapper.Map(likeDto, entity);

            _manager.Like.UpdateOneLike(entity);
            _manager.Save();
        }

        public void DeleteOneLike(int id, bool trackChanges)
        {
            var entity = _manager.Like.GetOneLikeById(id, trackChanges);
            if (entity == null) throw new EntityNotFoundException<Like>(id);

            _manager.Like.DeleteOneLike(entity);
            _manager.Save();
        }
    }
}
