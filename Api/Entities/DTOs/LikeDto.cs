using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class LikeDto
    {
        public int Id { get; set; }
        public bool IsLike { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        
    }
}
