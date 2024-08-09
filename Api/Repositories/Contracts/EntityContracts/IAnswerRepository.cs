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
        Task<IEnumerable<Answer>> GetAllAnswersAsync(bool trackChanges);
        Task<Answer> GetOneAnswerByIdAsync(int id, bool trackChanges);
        void CreateOneAnswer(Answer answer);
        void DeleteOneAnswer(Answer answer);
        void UpdateOneAnswer(Answer answer);
    }
}
