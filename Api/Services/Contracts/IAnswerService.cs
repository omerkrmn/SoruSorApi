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
        Task<IEnumerable<AnswerDto>> GetAllAnswersAsync(bool trackChanges);
        Task<AnswerDto> GetOneAnswerByIdAsync(int id, bool trackChanges);
        Task<AnswerDto> CreateAnswerAsync(AnswerDtoForInsert answer);
        Task UpdateOneAnswerAsync(AnswerDto answer, bool trackChanges);
        Task DeleteOneAnswerAsync(int id, bool trackChanges);
    }
}
