using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetAllQuestions(bool trackChanges);
        Question GetOneQuestionById(int id, bool trackChanges);
        Question CreateOneQuestion(Question question);
        void DeleteOneQuestion(int id, bool trackChanges);
    }
}
