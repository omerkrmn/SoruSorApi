using Entities.Models;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges) => 
            await FindAll(trackChanges)
            .Where(u => u.IsActive == true)
            .ToListAsync();
        public async Task<User> GetOneUserByIdAsync(int id, bool trackChanges) =>
             await FindByCondition(b => b.Id == id, trackChanges)
            .Where(u=>u.IsActive==true)
            .SingleOrDefaultAsync();
        public void UpdateOneUser(User user) => Update(user);
    }
}
