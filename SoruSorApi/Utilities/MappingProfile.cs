using AutoMapper;
using Entities.DTOs;
using Entities.Models;

namespace SoruSorApi.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDTO,User>();
            CreateMap<User,UserDTO>();

            //CreateMap<UserDtoForUpdate,User>();
            //CreateMap<User, UserDtoForUpdate>();

            //CreateMap<UserDtoForInsert,User>();
            //CreateMap<User, UserDtoForInsert>();
            CreateMap<Like, LikeDTO>();
            CreateMap<Answer, AnswerDTO>();
            CreateMap<Question, QuestionWithDetailsDTO>()
                .ForMember(dest => dest.Likes, opt => opt.MapFrom(src => src.Likes))
                .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answer));

            CreateMap<QuestionDTO,Question>();
            CreateMap<Question,QuestionDTO>();

            CreateMap<Answer, AnswerDTO>();
            CreateMap<AnswerDTO, Answer>();

            CreateMap<LikeDTO, Like>();
            CreateMap<Like, LikeDTO>();
        }
    }
}
