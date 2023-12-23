using Application.Features.Students.Commands.Create;
using Application.Features.Students.Commands.Delete;
using Application.Features.Students.Commands.Update;
using Application.Features.Students.Queries.GetById;
using Application.Features.Students.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.Students.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Student, CreateStudentCommand>().ReverseMap();
        CreateMap<Student, CreatedStudentResponse>().ReverseMap();
        CreateMap<Student, UpdateStudentCommand>().ReverseMap();
       
        CreateMap<Student, DeleteStudentCommand>().ReverseMap();
        CreateMap<Student, DeletedStudentResponse>().ReverseMap();
        CreateMap<Student, GetByIdStudentResponse>().ReverseMap();
        CreateMap<Student, GetListStudentListItemDto>().ReverseMap();
        CreateMap<Student, UpdateStudentDto>().ReverseMap();

        CreateMap<Student, GetListStudentListItemDto>()
       .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
       .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
       .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
       .ReverseMap();

        CreateMap<UpdateStudentDto, Student>()
       .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
       .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
       .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
       .ForMember(dest => dest.Biography, opt => opt.MapFrom(src => src.Biography))
       .ForMember(dest => dest.GithubUrl, opt => opt.MapFrom(src => src.GithubUrl))
       .ForMember(dest => dest.LinkedinUrl, opt => opt.MapFrom(src => src.LinkedinUrl))
       .ReverseMap();

        CreateMap<UpdateStudentDto, User>()
       .ForMember(dest => dest.Id, opt => opt.Ignore()) // Id alanýný dýþarýda býrak
       .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
       .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
       .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
       .ReverseMap();

        CreateMap<Student, UpdatedStudentResponse>()
       .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
       .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
       .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
       .ReverseMap();

        CreateMap<IPaginate<Student>, GetListResponse<GetListStudentListItemDto>>().ReverseMap();
    }
}