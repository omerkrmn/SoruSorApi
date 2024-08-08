using Entities.DTOs;
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
        IEnumerable<AnswerDto> GetAllAnswers(bool trackChanges);
        AnswerDto GetOneAnswerById(int id, bool trackChanges);
        AnswerDto CreateAnswer(AnswerDtoForInsert answer);
        void UpdateOneAnswer(AnswerDto answer, bool trackChanges);
        void DeleteOneAnswer(int id, bool trackChanges);
    }
}
