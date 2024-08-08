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

        public UserDto CreateOneUser(UserDtoForInsert userDtoForInsert)
        {
            if (userDtoForInsert == null)
                throw new ArgumentNullException(nameof(userDtoForInsert));
            var user = _mapper.Map<User>(userDtoForInsert); 
            _manager.User.CreateOneUser(user);
            _manager.Save();
            var entity = _mapper.Map<UserDto>(user);
            return entity;
        }

        public void DeleteOneUser(UserDto userDto, bool trackChanges)
        {
            var user = _manager.User.GetOneUserById(userDto.Id, trackChanges);
            if (user == null) throw new EntityNotFoundException<User>(userDto.Id);
            user.IsActive = false;
            _manager.Save();
        }


        public IEnumerable<UserDto> GetAllUsers(bool trackChanges)
        {
            var entities = _manager.User.GetAllUsers(trackChanges).Where(u=>u.IsActive == true);
            var users = _mapper.Map<IEnumerable<UserDto>>(entities);
            return users;
        }

        public UserDto GetOneUserById(int id, bool trackChanges)
        {
            var entity = _manager.User.GetOneUserById(id, trackChanges);
            if (entity == null) throw new EntityNotFoundException<User>(id);
            var user = _mapper.Map<UserDto>(entity);
            return user;
        }


        public UserDto UpdateOneUser(UserDto userDto, bool trackChanges)
        {
            if (userDto is null) throw new ArgumentNullException(nameof(userDto));
            var entity = _manager.User.GetOneUserById(userDto.Id, trackChanges);
          if (entity is null) throw new EntityNotFoundException<User>(userDto.Id);
            
            _mapper.Map(userDto, entity);
            _manager.User.UpdateOneUser(entity);
            _manager.Save();
            return userDto;
        }


    }
}
