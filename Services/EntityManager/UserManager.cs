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

        public User CreateOneUser(CreateForUserDTO createForUserDTO)
        {
            if (createForUserDTO == null) throw new ArgumentNullException(nameof(createForUserDTO));
            var user = _mapper.Map<User>(createForUserDTO);
            _manager.User.CreateOneUser(user);
            _manager.Save();
            return user;
        }

        public void DeleteOneUser(int id, bool trackChanges)
        {
            var user = _manager.User.GetOneUserById(id, trackChanges);
            if (user is null) throw new EntityNotFoundException<User>(id);
            _manager.User.DeleteOneUser(user);
            _manager.Save();
        }

        public IEnumerable<User> GetAllUsers(bool trackChanges)
        {
            var users = _manager.User.GetAllUsers(trackChanges);
            return users;
        }

        public User GetOneUserById(int id, bool trackChanges)
        {
            var user = _manager.User.GetOneUserById(id, trackChanges);
            if (user == null) throw new EntityNotFoundException<User>(id);
            return user;
        }

        public void UpdateOneUser(int id, User user, bool trackChanges)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            var entity = _manager.User.GetOneUserById(id, trackChanges);
            if (entity is null) throw new EntityNotFoundException<User>(id);

            // next quest use AutoMapper here
            //entity.Email = user.Email;
            //entity.PasswordHash = user.PasswordHash;



            _manager.User.UpdateOneUser(entity);
            _manager.Save();
        }
        public User GetOneUserWithQuestions(int id, bool trackChanges)
        {
          var user = _manager.User.GetAllUsers(trackChanges)
         .Include(u => u.Questions) // Yalnızca doğrudan ilişkili Questions yüklenir
         .Where(u=>u.Id == id)
         .FirstOrDefault();
            if (user == null) throw new EntityNotFoundException<User>(id);
            return user;
        }
    }
}
