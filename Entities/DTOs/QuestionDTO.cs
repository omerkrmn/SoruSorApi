using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class QuestionDTO
    {
        public string QuestionText { get; set; }
        public string? Answer { get; set; }

        public int AskedByUserID { get; set; }
        public int AskingTheUserID { get; set; }
    }
}
