using AutoMapper;
using ecommerce.Core.DTO;
using ecommerce.Core.Entities;
using System;

namespace ecommerce.Core.Mappers
{
    public class AutpMappings : Profile
    {
        public AutpMappings()
        {
            CreateMap<ApplicationUser, AuthenticationResponse>().
                ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.sucess, opt => opt.Ignore())
                .ForMember(dest => dest.token, opt => opt.Ignore());

        }
    }
}
