using Entities.DTOs;
using Entities.DTOs.UserDTOs;
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
        UserDTO CreateOneUser(UserDtoForInsert userDtoForInsert);
        void UpdateOneUser(int id, UserDtoForUpdate userDtoForUpdate, bool trackChanges);
        void DeleteOneUser(int id, bool trackChanges);
    }
}
    