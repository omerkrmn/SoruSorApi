using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts.EntityContracts
{
    public interface IQuestionRepository :IRepositoryBase<Question>
    {
        IQueryable<Question> GetAllQuestions(bool trackChanges);
        Question GetOneQuestionById(int id, bool trackChanges);
        void CreateOneQuestion(Question question);
        void DeleteOneQuestion(Question question);
        void UpdateOneQuestion(Question question);


    }
}
