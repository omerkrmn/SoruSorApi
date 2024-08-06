using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IAnswerService
    {
        IEnumerable<Answer> GetAllAnswers(bool trackChanges);
        Answer GetOneAnswerById(int id, bool trackChanges);
        Answer CreateAnswer(Answer answer);
        void UpdateOneAnswer(int id, Answer answer, bool trackChanges);
        void DeleteOneAnswer(int id, bool trackChanges);
    }
}
