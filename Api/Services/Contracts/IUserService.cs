using Entities.DTOs;
using Entities.Models;

namespace Services.Contracts
{
    public interface IUserService
    {
        Task<UserDto> CreateOneUserAsync(UserDtoForInsert userDtoForInsert);
        Task<IEnumerable<UserDto>> GetAllUsersAsync(bool trackChanges);
        Task<UserDto> GetOneUserByIdAsync(int id, bool trackChanges);
        Task<UserDto> UpdateOneUserAsync( UserDto userDto, bool trackChanges);
        Task DeleteOneUserAsync(UserDto userDto,bool trackChanges);
    }
}
    