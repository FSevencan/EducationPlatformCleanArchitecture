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
using Application.Features.Students.Queries.GetById.Dtos;
using Application.Features.Students.Queries.GetBySection;

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

        CreateMap<Student, GetListStudentListItemDto>().ReverseMap();
        CreateMap<Student, UpdateStudentDto>().ReverseMap();

        CreateMap<IPaginate<Student>, GetListResponse<GetListStudentListItemDto>>().ReverseMap();

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

        CreateMap<Student, GetByIdStudentResponse>()
       .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
       .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
       .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))

       .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.StudentSkills))
       .ForMember(dest => dest.Certificates, opt => opt.MapFrom(src => src.Certificates))


       .ForMember(dest => dest.ClassRoomNames, opt => opt.MapFrom(src => src.StudentClassRooms
                                                                       .Select(sc => sc.ClassRoom.Name)))

       .ForMember(dest => dest.Sections, opt => opt.MapFrom(src => src.StudentClassRooms
                                                                .SelectMany(sc => sc.ClassRoom
                                                                .ClassRoomType
                                                                .ClassRoomTypeSection
                                                                .Select(cts => cts.Section))))
       .ReverseMap();

        CreateMap<Section, SectionStudentDto>()
       .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
       .ForMember(dest => dest.Instructor, opt => opt.MapFrom(src => src.SectionInstructors.Select(s => s.Instructor)))
       .ForMember(dest=>dest.CourseCount, opt=>opt.MapFrom(src=>src.SectionCourses.Select(s=>s.Section).Count()))
       .ReverseMap();

        CreateMap<Instructor, SectionInstructorDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));

        CreateMap<Student, GetBySectionStudentResponse>()
            .ForMember(dest => dest.Sections, opt => opt.MapFrom(src => src.StudentClassRooms
                                                                .SelectMany(sc => sc.ClassRoom
                                                                .ClassRoomType
                                                                .ClassRoomTypeSection
                                                                .Select(cts => cts.Section))))
            .ReverseMap();

        CreateMap<Student, GetByUserIdStudentLockResponse>()
            .ForMember(dest => dest.Sections, opt => opt.MapFrom(src => src.StudentClassRooms
                                                                .SelectMany(sc => sc.ClassRoom
                                                                .ClassRoomType
                                                                .ClassRoomTypeSection
                                                                .Select(cts => cts.Section))))
       .ReverseMap();

        CreateMap<Section, GetLockDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();





    }
}