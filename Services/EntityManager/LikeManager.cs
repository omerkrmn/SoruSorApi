using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.EntityManager
{
    public class LikeManager : ILikeService
    {
        private readonly IRepositoryManager _manager;

        public LikeManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public Like CreateOneLike(Like like)
        {
            if (like == null) throw new ArgumentNullException(nameof(like));
            _manager.Like.CreateOneLike(like);
            _manager.Save();
            return like;
        }

        public void DeleteOneLike(int id, bool trackChanges)
        {
            var entity = _manager.Like.GetOneLikeById(id, trackChanges);
            if (entity == null) throw new EntityNotFoundException<Like>(id);
            _manager.Like.DeleteOneLike(entity);
            _manager.Save();
        }

        public IEnumerable<Like> GetAllLikes(bool trackChanges)
        {
            var likes = _manager.Like.GetAllLikes(trackChanges);
            return likes;
        }

        public Like GetOneLikeById(int id, bool trackChanges)
        {
            var like =  _manager.Like.GetOneLikeById(id, trackChanges);
            if(like == null) throw new EntityNotFoundException<Like>(id);
            return like;
        }

        public void UpdateOneLike(int id, Like like, bool trackChanges)
        {
            if (like == null) throw new ArgumentNullException();
            var entity = _manager.Like.GetOneLikeById(id, trackChanges);
            if (entity == null) throw new EntityNotFoundException<Like>(id);
            entity.IsLike=like.IsLike;
            _manager.Like.UpdateOneLike(entity);
            _manager.Save();
        }
    }
}
