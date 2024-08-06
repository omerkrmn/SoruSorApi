using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public class User : IdentityUser<int>
    {
        
        public int Age { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
