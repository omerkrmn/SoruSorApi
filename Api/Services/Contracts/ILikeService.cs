using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ILikeService
    {
        IEnumerable<LikeDto> GetAllLikes(bool trackChanges);
        LikeDto GetOneLikeById(int id, bool trackChanges);
        LikeDto CreateOneLike(LikeDtoForInsert likeInsertDto);
        void UpdateOneLike(int id, LikeDto likedto, bool trackChanges);
        void DeleteOneLike(int userId, int questionId, bool trackChanges);
    }
}
