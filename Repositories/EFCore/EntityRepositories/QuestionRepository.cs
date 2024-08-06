using Entities.Models;
using Repositories.Contracts.EntityContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.EntityRepositories
{
    public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        public QuestionRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneQuestion(Question question) => Create(question);

        public void DeleteOneQuestion(Question question)=>Delete(question);

        public IQueryable<Question> GetAllQuestions(bool trackChanges) => FindAll(trackChanges);
        public Question GetOneQuestionById(int id, bool trackChanges) => 
            FindByCondition(q => q.ID == id, trackChanges)
            .SingleOrDefault();
        public void UpdateOneQuestion(Question question)=>Update(question);
    }
}
