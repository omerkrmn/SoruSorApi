using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Answer : BaseEntity
    {
        public string? AnswerText { get; set; }

        [JsonIgnore]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
