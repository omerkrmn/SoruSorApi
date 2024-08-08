using Entities.DTOs;
using Entities.Models;

namespace Services.Contracts
{
    public interface IUserService
    {
        UserDto CreateOneUser(UserDtoForInsert userDtoForInsert);
        IEnumerable<UserDto> GetAllUsers(bool trackChanges);
        UserDto GetOneUserById(int id, bool trackChanges);
        UserDto UpdateOneUser( UserDto userDto, bool trackChanges);
        void DeleteOneUser(UserDto userDto,bool trackChanges);
    }
}
    