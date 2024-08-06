using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public record CreateForUserDTO
        (string UserName, string Email,int Age);
    
}
