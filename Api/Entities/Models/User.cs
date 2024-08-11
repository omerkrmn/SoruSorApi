using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class User : IdentityUser<int>
    {
        public string? NickName { get; set; }
        [EmailAddress]
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Question> QuestionsAsked { get; set; }
        public virtual ICollection<Question> QuestionsReceived { get; set; }
        public virtual ICollection<Like> Likes { get; set; } // Kullanıcının beğenileri
    }
}
