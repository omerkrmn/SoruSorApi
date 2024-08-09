using AutoMapper;
using Entities.DTOs;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.EntityManager
{
    public class UserManager : IUserService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public UserManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateOneUserAsync(UserDtoForInsert userDtoForInsert)
        {
            if (userDtoForInsert == null)
                throw new ArgumentNullException(nameof(userDtoForInsert));
            var user = _mapper.Map<User>(userDtoForInsert);
            _manager.User.CreateOneUser(user);
            await _manager.SaveAsync();
            var entity = _mapper.Map<UserDto>(user);
            return entity;
        }

        public async Task DeleteOneUserAsync(UserDto userDto, bool trackChanges)
        {
            var user = await _manager.User.GetOneUserByIdAsync(userDto.Id, trackChanges);
            if (user == null) throw new EntityNotFoundException<User>(userDto.Id);
            user.IsActive = false;
            await _manager.SaveAsync();
        }


        public async Task<IEnumerable<UserDto>> GetAllUsersAsync(bool trackChanges)
        {
            var entities = await _manager.User.GetAllUsersAsync(trackChanges);
            var users = _mapper.Map<IEnumerable<UserDto>>(entities);
            return users;
        }

        public async Task<UserDto> GetOneUserByIdAsync(int id, bool trackChanges)
        {
            var entity = await _manager.User.GetOneUserByIdAsync(id, trackChanges);
            if (entity == null) throw new EntityNotFoundException<User>(id);
            var user = _mapper.Map<UserDto>(entity);
            return user;
        }


        public async Task<UserDto> UpdateOneUserAsync(UserDto userDto, bool trackChanges)
        {
            if (userDto is null) throw new ArgumentNullException(nameof(userDto));
            var entity = await _manager.User.GetOneUserByIdAsync(userDto.Id, trackChanges);
            if (entity is null) throw new EntityNotFoundException<User>(userDto.Id);

             _mapper.Map(userDto, entity);
            _manager.User.UpdateOneUser(entity);
            await _manager.SaveAsync();
            return userDto;
        }


    }
}
