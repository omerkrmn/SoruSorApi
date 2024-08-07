using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{

    public class QuestionsAndDetailsOfUserDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public IEnumerable<QuestionWithDetailsDTO> Questions { get; set; }
    }
}
