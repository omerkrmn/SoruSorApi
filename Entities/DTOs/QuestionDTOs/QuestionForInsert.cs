using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.QuestionDTOs
{
    public record QuestionForInsert
    {
        public string QuestionText { get; init; }
        [Required]
        public int AskedByUserID { get; init; }
        [Required]
        public int AskingTheUserID { get; init; }
    }
}
