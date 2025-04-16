using AutoMapper;
using be.Data.Models;
using be.Dtos.Auth;

namespace be.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile(){
        
        CreateMap<RegisterDTO, User>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        CreateMap<User, AuthResponseDTO>();
    }
}