using Repositories.Contracts.EntityContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IQuestionRepository Question {  get; }
        IAnswerRepository Answer {  get; }
        ILikeRepository Like {  get; }
        Task SaveAsync();
    }
}
