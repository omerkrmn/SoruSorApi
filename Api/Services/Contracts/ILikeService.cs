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
        Task<IEnumerable<LikeDto>> GetAllLikesAsync(bool trackChanges);
        Task<LikeDto> GetOneLikeByIdAsync(int id, bool trackChanges);
        Task<LikeDto> CreateOneLikeAsync(LikeDtoForInsert likeInsertDto);
        Task UpdateOneLikeAsync(int id, LikeDto likedto, bool trackChanges);
        Task DeleteOneLikeAsync(int userId, int questionId, bool trackChanges);
    }
}
