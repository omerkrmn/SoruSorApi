using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Like
    {
        public int ID { get; set; }
        public bool IsLike { get; set; }
        public int QuestionID { get; set; }
        public int LikedByUserID { get; set; }

        [ForeignKey(nameof(QuestionID))]
        public virtual Question? Question { get; set; }


        [ForeignKey(nameof(LikedByUserID))]
        public virtual User LikedByUser { get; set; }
    }


}
