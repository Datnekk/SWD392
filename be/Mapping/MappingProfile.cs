using AutoMapper;
using be.Data.Models;
using be.Dtos.Auth;
using be.Dtos.Examination;

namespace be.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile(){
        
        CreateMap<RegisterDTO, User>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        CreateMap<User, AuthResponseDTO>();
        CreateMap<User, UserDTO>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ReverseMap();
        CreateMap<ExaminationDTO, Examination>()
            .ForMember(dest => dest.Exam_name, opt => opt.MapFrom(src => src.Exam_name))
            .ForMember(dest => dest.Exam_password, opt => opt.MapFrom(src => src.Exam_password))
            .ForMember(dest => dest.No_of_question, opt => opt.MapFrom(src => src.No_of_question))
            .ReverseMap();
    }
}