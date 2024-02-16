using Application.Features.StudentLessons.Commands.Create;
using Application.Features.StudentLessons.Commands.Delete;
using Application.Features.StudentLessons.Commands.Update;
using Application.Features.StudentLessons.Queries.GetById;
using Application.Features.StudentLessons.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.StudentLessons.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<StudentLesson, CreateStudentLessonCommand>().ReverseMap();
        CreateMap<StudentLesson, CreatedStudentLessonResponse>().ReverseMap();
        CreateMap<StudentLesson, UpdateStudentLessonCommand>().ReverseMap();
        CreateMap<StudentLesson, UpdatedStudentLessonResponse>().ReverseMap();
        CreateMap<StudentLesson, DeleteStudentLessonCommand>().ReverseMap();
        CreateMap<StudentLesson, DeletedStudentLessonResponse>().ReverseMap();
        CreateMap<StudentLesson, GetByIdStudentLessonResponse>().ReverseMap();
        CreateMap<StudentLesson, GetListStudentLessonListItemDto>().ReverseMap();
        CreateMap<IPaginate<StudentLesson>, GetListResponse<GetListStudentLessonListItemDto>>().ReverseMap();
    }
}