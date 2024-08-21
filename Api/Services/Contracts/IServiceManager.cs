 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IQuestionService QuestionService { get; }
        IUserService UserService { get; }
        ILikeService LikeService { get; }
        IAnswerService AnswerService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
