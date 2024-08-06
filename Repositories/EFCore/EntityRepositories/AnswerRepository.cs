using Entities.Models;
using Repositories.Contracts.EntityContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.EntityRepositories
{
    public class AnswerRepository : RepositoryBase<Answer>, IAnswerRepository
    {
        public AnswerRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneAnswer(Answer answer)=>Create(answer);

        public void DeleteOneAnswer(Answer answer)=>Delete(answer);

        public IQueryable<Answer> GetAllAnswers(bool trackChanges)=>FindAll(trackChanges);

        public Answer GetOneAnswerById(int id, bool trackChanges) =>
            FindByCondition(a => a.ID == id, trackChanges)
            .SingleOrDefault();
        public void UpdateOneAnswer(Answer answer)=>Update(answer);
    }
}
