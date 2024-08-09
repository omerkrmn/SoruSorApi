using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts.EntityContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.EntityRepositories
{
    public class LikeRepository : RepositoryBase<Like>, ILikeRepository
    {
        public LikeRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneLike(Like like) => Create(like);

        public void DeleteOneLike(Like like) => Delete(like);

        public async Task<IEnumerable<Like>> GetAllLikesAsync(bool trackChanges) => await FindAll(trackChanges).ToListAsync();

        public async Task<Like> GetOneLikeByIdAsync(int id, bool trackChanges) =>
           await FindByCondition(l => l.Id == id, trackChanges)
            .SingleOrDefaultAsync();

        public void UpdateOneLike(Like like) => Update(like);
    }
}
