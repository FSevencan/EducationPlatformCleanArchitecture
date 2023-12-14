using Application.Features.SectionCourses.Commands.Create;
using Application.Features.SectionCourses.Commands.Delete;
using Application.Features.SectionCourses.Commands.Update;
using Application.Features.SectionCourses.Queries.GetById;
using Application.Features.SectionCourses.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.SectionCourses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<SectionCourse, CreateSectionCourseCommand>().ReverseMap();
        CreateMap<SectionCourse, CreatedSectionCourseResponse>().ReverseMap();
        CreateMap<SectionCourse, UpdateSectionCourseCommand>().ReverseMap();
        CreateMap<SectionCourse, UpdatedSectionCourseResponse>().ReverseMap();
        CreateMap<SectionCourse, DeleteSectionCourseCommand>().ReverseMap();
        CreateMap<SectionCourse, DeletedSectionCourseResponse>().ReverseMap();
        CreateMap<SectionCourse, GetByIdSectionCourseResponse>().ReverseMap();
        CreateMap<SectionCourse, GetListSectionCourseListItemDto>().ReverseMap();
        CreateMap<IPaginate<SectionCourse>, GetListResponse<GetListSectionCourseListItemDto>>().ReverseMap();
    }
}