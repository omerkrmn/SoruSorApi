using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Question
    {
        public int ID { get; set; }
        public string QuestionText { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Answer { get; set; }

        public int AskedByUserID { get; set; }
        public int AskingTheUserID { get; set; }

        [ForeignKey(nameof(AskedByUserID))]
        public virtual User? AskedByUser { get; set; }
        [ForeignKey(nameof(AskingTheUserID))]
        public virtual User? AskingTheUser { get; set; }



        public virtual ICollection<Like>? Likes { get; set; }
    }


}
