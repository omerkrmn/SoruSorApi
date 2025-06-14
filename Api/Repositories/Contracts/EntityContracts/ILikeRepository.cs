﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts.EntityContracts
{
    public interface ILikeRepository : IRepositoryBase<Like>
    {
        Task<IEnumerable<Like>> GetAllLikesAsync(bool trackChanges);
        Task<Like> GetOneLikeByIdAsync(int id, bool trackChanges);
        void CreateOneLike(Like like);
        void DeleteOneLike(Like like);
        void UpdateOneLike(Like like);
    }
}
