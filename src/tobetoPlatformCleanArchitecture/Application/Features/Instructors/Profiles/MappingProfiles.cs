using Application.Features.Instructors.Commands.Create;
using Application.Features.Instructors.Commands.Delete;
using Application.Features.Instructors.Commands.Update;
using Application.Features.Instructors.Queries.GetById;
using Application.Features.Instructors.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.Sections.Queries.GetList;
using Core.Application.Dtos;
using Application.Features.Students.Commands.Update;
using Core.Security.Entities;
using Application.Features.Students.Queries.GetById.Dtos;

namespace Application.Features.Instructors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Instructor, CreateInstructorCommand>().ReverseMap();
        CreateMap<Instructor, CreatedInstructorResponse>().ReverseMap();
        CreateMap<Instructor, UpdateInstructorCommand>().ReverseMap();
        CreateMap<Instructor, UpdatedInstructorResponse>().ReverseMap();
        CreateMap<Instructor, DeleteInstructorCommand>().ReverseMap();
        CreateMap<Instructor, DeletedInstructorResponse>().ReverseMap();
        CreateMap<Instructor, GetByIdInstructorResponse>().ReverseMap();
        CreateMap<Instructor, GetListInstructorListItemDto>().ReverseMap();
        CreateMap<Instructor, GetListInstructorDto>().ReverseMap();

        CreateMap<IPaginate<Instructor>, GetListResponse<GetListInstructorListItemDto>>().ReverseMap();

        CreateMap<IPaginate<Instructor>, GetListResponse<GetListInstructorDto>>().ReverseMap();


        CreateMap<UpdateInstructorDto, Instructor>()
       .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
       .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
       .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
       .ForMember(dest => dest.Biography, opt => opt.MapFrom(src => src.Biography))
       .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
       .ReverseMap();

        CreateMap<UpdateInstructorDto, User>()
       .ForMember(dest => dest.Id, opt => opt.Ignore()) // Id alanini disarida birak
       .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
       .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
       .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
       .ReverseMap();


        CreateMap<Instructor, UpdatedInstructorResponse>()
       .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
       .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
       .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
       .ReverseMap();


        CreateMap<Instructor, GetListInstructorListItemDto>()
       .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
       .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
       .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));



        CreateMap<Instructor, GetListInstructorDto>()
       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));

        //GetById
        CreateMap<Instructor, GetByIdInstructorResponse>()
       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
       .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
       .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
       .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
       .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
       .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
       .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
       .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
       .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
       .ForMember(dest => dest.Sections, opt => opt.MapFrom(src => src.SectionInstructors.Select(si => si.Section)));

        CreateMap<Instructor, GetByIdInstructorLockResponse>()
            .ForMember(dest => dest.Sections, opt => opt.MapFrom(src => src.SectionInstructors.Select(si => si.Section)));

        CreateMap<Section, GetLockDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
    }
}