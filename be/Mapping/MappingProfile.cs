using AutoMapper;
using be.Data.Models;
using be.Data.Models.enums;
using be.Dtos.Answer;
using be.Dtos.Auth;
using be.Dtos.Examination;
using be.Dtos.Question;
using be.Dtos.Subject;
using be.Dtos.User;

namespace be.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile(){
        
        CreateMap<RegisterDTO, User>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        CreateMap<User, AuthResponseDTO>();
        CreateMap<User, UserDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ReverseMap()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<Status>(src.Status)));
        CreateMap<Examination, ExaminationDTO>()
            .ForMember(dest => dest.Subject_id, opt => opt.MapFrom(src => src.Subject_id))
            .ForMember(dest => dest.Exam_name, opt => opt.MapFrom(src => src.Exam_name))
            .ForMember(dest => dest.Exam_password, opt => opt.MapFrom(src => src.Exam_password))
            .ForMember(dest => dest.No_of_question, opt => opt.MapFrom(src => src.No_of_question))
            .ReverseMap();
        CreateMap<Examination, ExaminationCreateDTO>()
            .ForMember(dest => dest.Subject_id, opt => opt.MapFrom(src => src.Subject_id))
            .ForMember(dest => dest.Exam_name, opt => opt.MapFrom(src => src.Exam_name))
            .ForMember(dest => dest.Exam_password, opt => opt.MapFrom(src => src.Exam_password))
            .ForMember(dest => dest.No_of_question, opt => opt.MapFrom(src => src.No_of_question))
            .ReverseMap();
        CreateMap<Subject, SubjectDTO>()
            .ForMember(dest => dest.Subject_id, opt => opt.MapFrom(src => src.Subject_id))
            .ForMember(dest => dest.Subject_code, opt => opt.MapFrom(src => src.Subject_code))
            .ForMember(dest => dest.Subject_name, opt => opt.MapFrom(src => src.Subject_name))
            .ReverseMap();
        CreateMap<Subject, SubjectCreateDTO>()
            .ForMember(dest => dest.Subject_code, opt => opt.MapFrom(src => src.Subject_code))
            .ForMember(dest => dest.Subject_name, opt => opt.MapFrom(src => src.Subject_name))
            .ReverseMap();
        CreateMap<Question, QuestionDTO>()
            .ForMember(dest => dest.Question_id, opt => opt.MapFrom(src => src.Question_id))
            .ForMember(dest => dest.Subject_id, opt => opt.MapFrom(src => src.Subject_id))
            .ForMember(dest => dest.Question_text, opt => opt.MapFrom(src => src.Question_text))
            .ForMember(dest => dest.Question_type, opt => opt.MapFrom(src => src.Question_type.ToString()))
            .ReverseMap()
            .ForMember(dest => dest.Question_type, opt => opt.MapFrom(src => Enum.Parse<QuestionType>(src.Question_type)));
        CreateMap<Question, QuestioneCreateDTO>()
            .ForMember(dest => dest.Subject_id, opt => opt.MapFrom(src => src.Subject_id))
            .ForMember(dest => dest.Question_text, opt => opt.MapFrom(src => src.Question_text))
            .ForMember(dest => dest.Question_type, opt => opt.MapFrom(src => src.Question_type))
            .ReverseMap();
        CreateMap<Answer, AnswerDTO>()
            .ForMember(dest => dest.Answer_id, opt => opt.MapFrom(src => src.Answer_id))
            .ForMember(dest => dest.Question_id, opt => opt.MapFrom(src => src.Question_id))
            .ForMember(dest => dest.Answer_text, opt => opt.MapFrom(src => src.Answer_text))
            .ForMember(dest => dest.Is_Correct, opt => opt.MapFrom(src => src.Is_Correct))
            .ReverseMap();
        CreateMap<Answer, AnswerCreateDTO>()
            .ForMember(dest => dest.Question_id, opt => opt.MapFrom(src => src.Question_id))
            .ForMember(dest => dest.Answer_text, opt => opt.MapFrom(src => src.Answer_text))
            .ForMember(dest => dest.Is_Correct, opt => opt.MapFrom(src => src.Is_Correct))
            .ReverseMap();
    }
}