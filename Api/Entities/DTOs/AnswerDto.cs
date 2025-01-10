using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs
{
    public class AnswerDto
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public int QuestionId { get; set; }
        public int AnsweredById { get; set; }
    }
}
