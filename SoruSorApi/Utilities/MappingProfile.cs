using AutoMapper;
using Entities.DTOs;
using Entities.DTOs.AnswerDTOs;
using Entities.DTOs.UserDTOs;
using Entities.Models;

namespace SoruSorApi.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDTO,User>();
            CreateMap<User,UserDTO>();

            CreateMap<UserDtoForUpdate,User>();
            CreateMap<User, UserDtoForUpdate>();

            CreateMap<UserDtoForInsert,User>();
            CreateMap<User, UserDtoForInsert>();

            CreateMap<Answer, AnswerDTO>();
            CreateMap<AnswerDTO, Answer>();
        }
    }
}
