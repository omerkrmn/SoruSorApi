using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts.EntityContracts
{
    public interface IQuestionRepository :IRepositoryBase<Question>
    {
        Task<IEnumerable<Question>> GetAllQuestionsAsync(QuestionParameters questionParameters, bool trackChanges);
        Task<Question> GetOneQuestionByIdAsync(int id, bool trackChanges);
        void CreateOneQuestion(Question question);
        void DeleteOneQuestion(Question question);
        void UpdateOneQuestion(Question question);



    }
}
