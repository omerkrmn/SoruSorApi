using System.Collections.Generic;

namespace Entities.DTOs
{
    public class QuestionsDetailsDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int AskedById { get; set; }
        public int ReciveUserId { get; set; }
        public int LikeCount { get; set; } // Beğeni sayısı
        public int DislikeCount { get; set; } // Beğenmeme sayısı
        public AnswerDto Answer { get; set; }
    }
}
