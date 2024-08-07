using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Like : BaseEntity
    {
        public bool IsLike { get; set; }

        public int QuestionID { get; set; }
        public virtual Question? Question { get; set; }

        public int LikedByUserID { get; set; }
        public virtual User LikedByUser { get; set; }
    }


}
