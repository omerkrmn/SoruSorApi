using AutoMapper;
using Entities.DTOs;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.EntityManager
{
    public class QuestionManager : IQuestionService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public QuestionManager(IRepositoryManager manager, IMapper mapper, UserManager<User> userManager)
        {
            _manager = manager;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<QuestionDto> CreateOneQuestionAsync(QuestionDtoForInsert questionDto)
        {
            if (questionDto == null)
                throw new ArgumentNullException(nameof(questionDto), "QuestionDTO cannot be null.");
            var question = _mapper.Map<Question>(questionDto);
            _manager.Question.CreateOneQuestion(question);
            await _manager.SaveAsync();
            var createdQuestionDto = _mapper.Map<QuestionDto>(question);
            return createdQuestionDto;
        }



        public async Task<IEnumerable<QuestionDto>> GetAllQuestionsAsync(QuestionParameters questionParameters,bool trackChanges)
        {
            var questions =await _manager.Question.GetAllQuestionsAsync(questionParameters,trackChanges);
            var questionDtos = _mapper.Map<IEnumerable<QuestionDto>>(questions);
            return questionDtos;
        }

        public async Task<QuestionDto >GetOneQuestionByIdAsync(int id, bool trackChanges)
        {
            var question =await _manager.Question.GetOneQuestionByIdAsync(id, trackChanges);
            if (question == null)
                throw new EntityNotFoundException<Question>(id);
            var questionDto = _mapper.Map<QuestionDto>(question);

            return questionDto;
        }


        public async Task<IEnumerable<QuestionsDetailsDTO>> GetAllQuestionWithUserIdAsync(int userId)
        {
            var user = _userManager.Users.Where(u=>u.Id == userId).FirstOrDefault();
            if (user == null) throw new EntityNotFoundException<User>(userId);

            var userQuestions = await _manager.Question
                .FindByCondition(q => q.ReciveUserId == userId, false)
                .Include(q => q.Likes) 
                .Include(q => q.Answer) 
                .ToListAsync();

            var questionsDetailsDto = userQuestions.Select(question => new QuestionsDetailsDTO
            {
                Id = question.Id,
                Content = question.Content,
                AskedById = question.AskedById,
                ReciveUserId = question.ReciveUserId,
                LikeCount = question.Likes.Count(like => like.IsLike), 
                DislikeCount = question.Likes.Count(like => !like.IsLike), 
                Answer = _mapper.Map<AnswerDto>(question.Answer)
            }).ToList();

            return questionsDetailsDto;
        }



    }
}
