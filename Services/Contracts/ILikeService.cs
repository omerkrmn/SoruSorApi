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
        IEnumerable<Like> GetAllLikes(bool trackChanges);
        Like GetOneLikeById(int id, bool trackChanges);
        LikeDTO CreateOneLike(LikeDTO like);
        void UpdateOneLike(int id, Like like, bool trackChanges);
        void DeleteOneLike(int id, bool trackChanges);
    }
}
