using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
