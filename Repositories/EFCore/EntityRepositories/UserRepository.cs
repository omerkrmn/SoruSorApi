using Entities.Models;
using Repositories.Contracts.EntityContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.EntityRepositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneUser(User user) => Create(user);

        public void DeleteOneUser(User user) => Delete(user);

        public IQueryable<User> GetAllUsers(bool trackChanges) => FindAll(trackChanges);

        public User GetOneUserById(int id, bool trackChanges) =>
            FindByCondition(b => b.Id == id, trackChanges)
            .SingleOrDefault();

        public void UpdateOneUser(User user) => Update(user);
    }
}
