using Entities.Models;
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

        public IQueryable<Like> GetAllLikes(bool trackChanges) => FindAll(trackChanges);

        public Like GetOneLikeById(int id, bool trackChanges) =>
            FindByCondition(l => l.ID == id, trackChanges)
            .SingleOrDefault();

        public void UpdateOneLike(Like like) => Update(like);
    }
}
