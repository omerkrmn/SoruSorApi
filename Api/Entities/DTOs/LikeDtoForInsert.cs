﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class LikeDtoForInsert
    {
        public bool IsLike { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
    }
}
