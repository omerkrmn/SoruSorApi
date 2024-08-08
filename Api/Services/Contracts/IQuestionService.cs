using Entities.DTOs;
using Entities.Models;

namespace Services.Contracts
{
    public interface IQuestionService
    {
        QuestionDto CreateOneQuestion(QuestionDtoForInsert questionDtoForInsert);
        IEnumerable<QuestionDto> GetAllQuestions(bool trackChanges);
        QuestionDto GetOneQuestionById(int id, bool trackChanges);
        IEnumerable<QuestionsDetailsDTO> GetAllQuestionWithUserId(int id);
        
    }
}
