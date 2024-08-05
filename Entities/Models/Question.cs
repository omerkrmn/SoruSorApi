using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Question : BaseEntity
    {
        public string QuestionText { get; set; }
        

        public int AskedByUserID { get; set; }
        public int AskingTheUserID { get; set; }



        [ForeignKey(nameof(AskedByUserID))]
        [JsonIgnore]
        public virtual User? AskedByUser { get; set; }

        [ForeignKey(nameof(AskingTheUserID))]
        [JsonIgnore]
        public virtual User? AskingTheUser { get; set; }



        public virtual Answer? Answer { get; set; }
        public virtual ICollection<Like>? Likes { get; set; }
    }


}
