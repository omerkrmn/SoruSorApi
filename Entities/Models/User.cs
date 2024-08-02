using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }
        public int Age { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
