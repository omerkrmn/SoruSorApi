using Entities.DTOs;
using Entities.Models;
using Entities.RequestFeatures;

namespace Services.Contracts
{
    public interface IQuestionService
    {
        Task<QuestionDto> CreateOneQuestionAsync(QuestionDtoForInsert questionDtoForInsert);
        Task<IEnumerable<QuestionDto>> GetAllQuestionsAsync(QuestionParameters questionParameters,bool trackChanges);
        Task<QuestionDto> GetOneQuestionByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<QuestionsDetailsDTO>> GetAllQuestionWithUserIdAsync(int id);
        
    }
}
