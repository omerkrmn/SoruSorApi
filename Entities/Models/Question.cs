using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Question : BaseEntity
    {
        [Required(ErrorMessage ="QuestionText is a required field")]
        public string QuestionText { get; set; }

        public int AskedByUserID { get; set; }
        public int AskingTheUserID { get; set; }


        [JsonIgnore]
        public virtual User AskedByUser { get; set; }
        [JsonIgnore]
        public virtual User AskingTheUser { get; set; }
        public virtual Answer? Answer { get; set; }
        public virtual ICollection<Like>? Likes { get; set; }
    }


}
