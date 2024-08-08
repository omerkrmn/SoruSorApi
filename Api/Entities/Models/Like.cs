using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Like
    {
        public int Id { get; set; }
        public bool IsLike { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }

}
