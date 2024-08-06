using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EntityManager
{
    public class UserManager : IUserService
    {
        private readonly IRepositoryManager _manager;

        public UserManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public User CreateOneUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            _manager.User.CreateOneUser(user);
            _manager.Save();
            return user;
        }

        public void DeleteOneUser(int id, bool trackChanges)
        {
            var entity = _manager.User.GetOneUserById(id, trackChanges);
            if (entity == null) throw new Exception("User is not found!");
            _manager.User.DeleteOneUser(entity);
            _manager.Save();
        }

        public IEnumerable<User> GetAllUsers(bool trackChanges)
        {
            var users = _manager.User.GetAllUsers(trackChanges);
            return users;
        }

        public User GetOneUserById(int id, bool trackChanges)
        {
            return _manager.User.GetOneUserById(id, trackChanges);
        }

        public void UpdateOneUser(int id, User user, bool trackChanges)
        {
            var entity = _manager.User.GetOneUserById(id, trackChanges);
            if (entity == null) throw new Exception("user is not found");
            if (user == null) throw new Exception("user is null");
            entity.Email = user.Email;
            entity.Password = user.Password;

            _manager.User.UpdateOneUser(entity);
            _manager.Save();
        }
    }
}
