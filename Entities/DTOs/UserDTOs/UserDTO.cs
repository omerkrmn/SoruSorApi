using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.UserDTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string PasswordHash { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }

}
