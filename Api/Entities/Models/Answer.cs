using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Answer
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
