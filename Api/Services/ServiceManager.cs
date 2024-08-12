using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Contracts;
using Services.EntityManager;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _userService; // gidici :( boşa uğraştık
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IAnswerService> _answerService;
        private readonly Lazy<IQuestionService> _questionService;
        private readonly Lazy<ILikeService> _likeService;

        public ServiceManager(IRepositoryManager manager, IMapper mapper, IConfiguration configuration, UserManager<User> userManager)
        {
            _userService = new Lazy<IUserService>(() => new UserManager(manager, mapper));
            
            _answerService = new Lazy<IAnswerService>(() => new AnswerManager(manager, mapper));
            _questionService = new Lazy<IQuestionService>(() => new QuestionManager(manager, mapper,userManager));
            _likeService = new Lazy<ILikeService>(() => new LikeManager(manager, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationManager(userManager, mapper, configuration));
        }
        public IUserService UserService => _userService.Value;
        public IQuestionService QuestionService => _questionService.Value;
        public ILikeService LikeService => _likeService.Value;
        public IAnswerService AnswerService => _answerService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
