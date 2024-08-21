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
        private readonly UserManager<User> userManager;

        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IAnswerService> _answerService;
        private readonly Lazy<IQuestionService> _questionService;
        private readonly Lazy<ILikeService> _likeService;

        public ServiceManager(IRepositoryManager manager, IMapper mapper, IConfiguration configuration, UserManager<User> userManager)
        {
            this.userManager = userManager;
            _userService =new Lazy<IUserService> (()=>new UserManager(mapper,userManager,configuration));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationManager(userManager, mapper, configuration));
            _answerService = new Lazy<IAnswerService>(() => new AnswerManager(manager, mapper));
            _questionService = new Lazy<IQuestionService>(() => new QuestionManager(manager, mapper, userManager));
            _likeService = new Lazy<ILikeService>(() => new LikeManager(manager, mapper));
        }
        public IQuestionService QuestionService => _questionService.Value;
        public ILikeService LikeService => _likeService.Value;
        public IAnswerService AnswerService => _answerService.Value;

        public IUserService UserService => _userService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
