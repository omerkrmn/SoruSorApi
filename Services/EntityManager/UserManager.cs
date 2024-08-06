using AutoMapper;
using Entities.DTOs;
using Entities.DTOs.UserDTOs;
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

        public UserDTO CreateOneUser(UserDtoForInsert userDtoForInsert)
        {
            if (userDtoForInsert == null)
                throw new ArgumentNullException(nameof(userDtoForInsert)); // Doğru parametre adı kullanıldı.

            var user = _mapper.Map<User>(userDtoForInsert); // userDtoForInsert'dan User nesnesi oluşturuldu.
            _manager.User.CreateOneUser(user); // User nesnesi oluşturuldu.
            _manager.Save(); // Veritabanına kaydedildi.
            var userdto = _mapper.Map<UserDTO>(user); // Oluşturulan User nesnesi UserDTO'ya dönüştürüldü.
            return userdto; // UserDTO döndürüldü.
        }

        public void DeleteOneUser(int id, bool trackChanges)
        {
            var user = _manager.User.GetAllUsers(trackChanges)
                .Include(b=>b.Questions)
                .ThenInclude(b=>b.Answer)
                .Where(u=>u.Id == id)
                .SingleOrDefault();

            if (user == null) throw new EntityNotFoundException<User>(id);


            _manager.User.DeleteOneUser(user); // Remove kullanarak entity'yi silin
            _manager.Save(); // Değişiklikleri veritabanına kaydedin
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

        public void UpdateOneUser(int id, UserDtoForUpdate userDtoForUpdate, bool trackChanges)
        {
            if (userDtoForUpdate is null) throw new ArgumentNullException(nameof(userDtoForUpdate));
            var entity = _manager.User.GetOneUserById(id, trackChanges);
            if (entity is null)
                throw new EntityNotFoundException<User>(id);

            _mapper.Map(userDtoForUpdate, entity);

            _manager.User.UpdateOneUser(entity);
            _manager.Save();
        }
    }
}
