using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts.EntityContracts
{
    public interface IUserRepository :IRepositoryBase<User>
    {
        Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges);
        Task<User> GetOneUserByIdAsync(int id,bool trackChanges);
        void CreateOneUser(User user);
        void DeleteOneUser(User user);
        void UpdateOneUser(User user);

    }
}
