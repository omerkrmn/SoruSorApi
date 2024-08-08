using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class QuestionDtoForInsert
    {
        public string Content { get; set; }
        public int AskedById { get; set; }
        public int ReciveUserId { get; set; }
    }
}
