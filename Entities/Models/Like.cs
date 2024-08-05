using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Like : BaseEntity
    {
        public bool IsLike { get; set; }
        public int QuestionID { get; set; }
        public int LikedByUserID { get; set; }

        [ForeignKey(nameof(QuestionID))]
        public virtual Question? Question { get; set; }


        [ForeignKey(nameof(LikedByUserID))]
        public virtual User LikedByUser { get; set; }
    }


}
