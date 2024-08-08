using AutoMapper;
using Entities.DTOs;
using Entities.Models;

namespace SoruSorApi.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User mappings
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<UserDtoForInsert, User>();
            CreateMap<User, UserDtoForInsert>();

            // Question mappings
            CreateMap<Question, QuestionDto>();
            CreateMap<QuestionDto, Question>();
            CreateMap<QuestionDtoForInsert, Question>();
            CreateMap<Question, QuestionDtoForInsert>();

            // Answer mappings
            CreateMap<Answer, AnswerDto>();
            CreateMap<AnswerDto, Answer>();
            CreateMap<AnswerDtoForInsert, Answer>();
            CreateMap<Answer, AnswerDtoForInsert>();

            // Like mappings
            CreateMap<Like, LikeDto>();
            CreateMap<LikeDto, Like>();
            CreateMap<Like, LikeDtoForInsert>();
            CreateMap<LikeDtoForInsert, Like>();

            // Mapping for QuestionsDetailsDTO
            CreateMap<Question, QuestionsDetailsDTO>()
                .ForMember(dest => dest.LikeCount, opt => opt.MapFrom(src => src.Likes.Count(like => like.IsLike)))
                .ForMember(dest => dest.DislikeCount, opt => opt.MapFrom(src => src.Likes.Count(like => !like.IsLike)))
                .ForMember(dest => dest.Answer, opt => opt.MapFrom(src => src.Answer));

            CreateMap<QuestionsDetailsDTO, Question>()
                .ForMember(dest => dest.Answer, opt => opt.MapFrom(src => src.Answer))
                .ForMember(dest => dest.Likes, opt => opt.Ignore()); // Ignore Likes during mapping
        }
    }
}
