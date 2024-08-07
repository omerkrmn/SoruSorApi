namespace Entities.DTOs
{
    public class QuestionWithDetailsDTO
    {
        public int ID { get; set; }
        public string QuestionText { get; set; }
        public IEnumerable<LikeDTO> Likes { get; set; }
        public IEnumerable<AnswerDTO> Answers { get; set; }
    }
}
