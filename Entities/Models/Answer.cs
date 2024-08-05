using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Answer : BaseEntity
    {
        public string? AnswerText { get; set; }
        public int QuestionId { get; set; }

        [ForeignKey(nameof(QuestionId))]
        [JsonIgnore]
        public virtual Question Question { get; set; }
    }
}
