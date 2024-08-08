using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AskedById { get; set; }
        public User AskedBy { get; set; }
        public int ReciveUserId { get; set; }
        public virtual User ReciveUser { get; set; }
        public int? AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
        public virtual ICollection<Like> Likes { get; set; } // Sorunun beğenileri
    }
}
