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

        public UserDTO CreateOneUser(UserDTO userDTO)
        {
            if (userDTO == null)
                throw new ArgumentNullException(nameof(userDTO)); 

            var user = _mapper.Map<User>(userDTO); 
            _manager.User.CreateOneUser(user); 
            _manager.Save(); 
            var userdto = _mapper.Map<UserDTO>(user); 
            return userdto;
        }

        public void DeleteOneUser(int id, bool trackChanges)
        {
            // Kodumun hatası burada !!!!!
        }


        public IEnumerable<UserDTO> GetAllUsers(bool trackChanges)
        {
            var users = _manager.User.GetAllUsers(trackChanges);
            var dtos = _mapper.Map<IEnumerable<UserDTO>>(users);
            return dtos;
        }

        public UserDTO GetOneUserById(int id, bool trackChanges)
        {
            var entity = _manager.User.GetOneUserById(id, trackChanges);
            if (entity == null) throw new EntityNotFoundException<User>(id);
            var user = _mapper.Map<UserDTO>(entity);
            return user;
        }

        public void UpdateOneUser(int id, UserDTO userDTO, bool trackChanges)
        {
            if (userDTO is null) throw new ArgumentNullException(nameof(userDTO));
            var entity = _manager.User.GetOneUserById(id, trackChanges);
            if (entity is null)
                throw new EntityNotFoundException<User>(id);

            _mapper.Map(userDTO, entity);

            _manager.User.UpdateOneUser(entity);
            _manager.Save();
        }
    }
}
