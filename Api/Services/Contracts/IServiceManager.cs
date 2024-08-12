 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
        IQuestionService QuestionService { get; }
        ILikeService LikeService { get; }
        IAnswerService AnswerService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
