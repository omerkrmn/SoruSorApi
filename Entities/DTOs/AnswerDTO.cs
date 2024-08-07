using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AnswerDTO
    {
        public int ID { get; set; }
        public string AnswerText { get; set; }
        public int QuestionId { get; set; }
    }
}
