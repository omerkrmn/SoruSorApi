using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts.EntityContracts;
using System;
using System.Collections;
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

        public async Task<IEnumerable<Answer>> GetAllAnswersAsync(bool trackChanges)=>
            await FindAll(trackChanges).ToListAsync();

        public async Task<Answer> GetOneAnswerByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(a => a.Id == id, trackChanges)
            .SingleOrDefaultAsync();
        public void UpdateOneAnswer(Answer answer)=>Update(answer);
    }
}
