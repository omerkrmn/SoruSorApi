using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
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

        public void DeleteOneQuestion(Question question) => Delete(question);

        //
        public async Task<IEnumerable<Question>> GetAllQuestionsAsync(QuestionParameters questionParameters, bool trackChanges) =>
            await FindAll(trackChanges)
            .Skip((questionParameters.PageNumber - 1) * questionParameters.PageSize)
            .Take(questionParameters.PageSize)
            .ToListAsync();
        public async Task<Question> GetOneQuestionByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(q => q.Id == id, trackChanges)
            .SingleOrDefaultAsync();
        public void UpdateOneQuestion(Question question) => Update(question);
    }
}
