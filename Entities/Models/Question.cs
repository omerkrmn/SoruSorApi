using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Question : BaseEntity
    {
        [Required(ErrorMessage ="QuestionText is a required field")]
        [StringLength(150,MinimumLength =3,ErrorMessage = "QuestionText must be between 3 and 100 characters")]
        public string QuestionText { get; set; }

        public int AskedByUserID { get; set; }
        public int AskingTheUserID { get; set; }



        [ForeignKey(nameof(AskedByUserID))]
        [JsonIgnore]
        public virtual User AskedByUser { get; set; }

        [ForeignKey(nameof(AskingTheUserID))]
        [JsonIgnore]
        public virtual User AskingTheUser { get; set; }

        public virtual Answer? Answer { get; set; }
        public virtual ICollection<Like>? Likes { get; set; }
    }


}
