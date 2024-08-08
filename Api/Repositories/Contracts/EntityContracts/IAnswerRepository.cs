using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts.EntityContracts
{
    public interface IAnswerRepository : IRepositoryBase<Answer>
    {
        IQueryable<Answer> GetAllAnswers(bool trackChanges);
        Answer GetOneAnswerById(int id, bool trackChanges);
        void CreateOneAnswer(Answer answer);
        void DeleteOneAnswer(Answer answer);
        void UpdateOneAnswer(Answer answer);
    }
}
