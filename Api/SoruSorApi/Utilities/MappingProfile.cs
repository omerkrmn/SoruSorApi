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
            CreateMap<UserForRegisterDTO,User>();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDtoForInsert, User>().ReverseMap();

            // Question mappings
            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<QuestionDtoForInsert, Question>().ReverseMap();

            // Answer mappings
            CreateMap<Answer, AnswerDto>().ReverseMap();
            CreateMap<AnswerDtoForInsert, Answer>().ReverseMap();

            // Like mappings
            CreateMap<Like, LikeDto>().ReverseMap();
            CreateMap<Like, LikeDtoForInsert>().ReverseMap();

            // Mapping for QuestionsDetailsDTO
            CreateMap<Question, QuestionsDetailsDTO>()
                .ForMember(dest => dest.LikeCount, opt => opt.MapFrom(src => src.Likes.Count(like => like.IsLike)))
                .ForMember(dest => dest.DislikeCount, opt => opt.MapFrom(src => src.Likes.Count(like => !like.IsLike)))
                .ForMember(dest => dest.Answer, opt => opt.MapFrom(src => src.Answer));

            CreateMap<QuestionsDetailsDTO, Question>()
                .ForMember(dest => dest.Answer, opt => opt.MapFrom(src => src.Answer))
                .ForMember(dest => dest.Likes, opt => opt.Ignore()); 
        }
    }
}
