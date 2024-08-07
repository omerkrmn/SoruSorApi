using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class LikeDTO
    {
        public int ID { get; set; }
        public bool IsLike { get; set; }
        public int QuestionID { get; set; }
        public int LikedByUserID { get; set; }

    }
}
