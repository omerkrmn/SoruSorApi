using AutoMapper;
using Entities.DTOs;
using Entities.DTOs.AnswerDTOs;
using Entities.Models;

namespace SoruSorApi.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateForUserDTO, User>();
            CreateMap<User, CreateForUserDTO>();
            CreateMap<Answer, AnswerDTO>();
            CreateMap<AnswerDTO, Answer>();
        }
    }
}
