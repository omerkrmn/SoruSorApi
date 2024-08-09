using Repositories.Contracts;
using Repositories.Contracts.EntityContracts;
using Repositories.EFCore.EntityRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;

        #region LazyLoading For Repositories
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IQuestionRepository> _questionRepository;
        private readonly Lazy<IAnswerRepository> _answerRepository;
        private readonly Lazy<ILikeRepository> _likeRepository;
        #endregion
        
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            #region Create Lazy Instance
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_context));
            _answerRepository = new Lazy<IAnswerRepository>(() => new AnswerRepository(_context));
            _likeRepository = new Lazy<ILikeRepository>(() => new LikeRepository(_context));
            _questionRepository = new Lazy<IQuestionRepository>(() => new QuestionRepository(_context));
            #endregion
        }

        #region Return Instance Value
        public IUserRepository User => _userRepository.Value;
        public IQuestionRepository Question => _questionRepository.Value;
        public IAnswerRepository Answer => _answerRepository.Value;
        public ILikeRepository Like => _likeRepository.Value;
        #endregion

        public Task SaveAsync() => _context.SaveChangesAsync();

    }
}
