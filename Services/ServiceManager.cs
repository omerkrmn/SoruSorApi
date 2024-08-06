using AutoMapper;
using Repositories.Contracts;
using Services.Contracts;
using Services.EntityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IAnswerService> _answerService;
        private readonly Lazy<IQuestionService> _questionService;
        private readonly Lazy<ILikeService> _likeService;
        
        public ServiceManager(IRepositoryManager manager,IMapper mapper)
        {
            _userService = new Lazy<IUserService>(() => new UserManager(manager,mapper));
            _answerService = new Lazy<IAnswerService>(() => new AnswerManager(manager,mapper));
            _questionService = new Lazy<IQuestionService>(() => new QuestionManager(manager));
            _likeService = new Lazy<ILikeService>(() => new LikeManager(manager));
        }
        public IUserService UserService => _userService.Value;
        public IQuestionService QuestionService => _questionService.Value;
        public ILikeService LikeService => _likeService.Value;
        public IAnswerService AnswerService => _answerService.Value;
    }
}
