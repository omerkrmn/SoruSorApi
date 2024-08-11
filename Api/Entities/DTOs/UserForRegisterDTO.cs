using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public sealed record class UserForRegisterDTO
    {
        public string UserName { get; set; }
        public string NickName { get; init; }
        public string Password { get; init; }
        public string Email { get; init; }
        public ICollection<string>? Roles { get; init; }
    }  
}
