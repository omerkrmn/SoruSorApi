using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? NickName { get; set; }
        [EmailAddress]
        public string Mail{ get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Question> QuestionsAsked { get; set; }
        public virtual ICollection<Question> QuestionsReceived { get; set; }
        public virtual ICollection<Like> Likes { get; set; } // Kullanıcının beğenileri
    }
}
