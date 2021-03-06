﻿using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.User;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.Mapper
{
    public class UserDTOProfile : AutoMapperProfile
    {
        public UserDTOProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.SecondName, opt => opt.MapFrom(src => src.SecondName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneNumber));
            
            CreateMap<UserFullInfoDTO, User>();
            CreateMap<User, UserFullInfoDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<UserCreationDTO, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => ($"{src.FirstName}{src.SecondName}")));

        }
    }
}
