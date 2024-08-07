using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAllUsers(bool trackChanges);
        UserDTO GetOneUserById(int id, bool trackChanges);
        UserDTO CreateOneUser(UserDTO userDtoForInsert);
        void UpdateOneUser(int id, UserDTO userDtoForUpdate, bool trackChanges);
        void DeleteOneUser(int id, bool trackChanges);
    }
}
    