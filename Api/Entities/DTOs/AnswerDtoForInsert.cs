using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AnswerDtoForInsert
    {
        public string Content { get; set; }
        public int QuestionId { get; set; }
        public int AnsweredById { get; set; }
    }
}
