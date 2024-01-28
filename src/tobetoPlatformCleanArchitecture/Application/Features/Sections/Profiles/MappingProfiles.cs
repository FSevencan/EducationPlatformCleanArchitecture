using Application.Features.Sections.Commands.Create;
using Application.Features.Sections.Commands.Delete;
using Application.Features.Sections.Commands.Update;
using Application.Features.Sections.Queries.GetById;
using Application.Features.Sections.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.Categories.Queries.GetList;
using Application.Features.Instructors.Queries.GetList;
using Application.Features.Courses.Queries.GetList;
using Application.Features.Students.Queries.GetById.Dtos;
using Application.Features.Sections.Queries.GetById.Dtos;

namespace Application.Features.Sections.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Section, CreateSectionCommand>().ReverseMap();
        CreateMap<Section, CreatedSectionResponse>().ReverseMap();
        CreateMap<Section, UpdateSectionCommand>().ReverseMap();
        CreateMap<Section, UpdatedSectionResponse>().ReverseMap();
        CreateMap<Section, DeleteSectionCommand>().ReverseMap();
        CreateMap<Section, DeletedSectionResponse>().ReverseMap();
        CreateMap<Section, GetByIdSectionResponse>()
        .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.SectionCourses.Select(sc => sc.Course)));

        CreateMap<Section, GetListCategorySectionsDto>().ReverseMap();
        CreateMap<Section, GetListInstructorsSectionListDto>().ReverseMap();
        CreateMap<IPaginate<Section>, GetListResponse<GetListSectionListItemDto>>().ReverseMap();
        CreateMap<IPaginate<Section>, GetListResponse<GetListInstructorsSectionListDto>>().ReverseMap();


        CreateMap<Section, GetListSectionListItemDto>()
            .ForMember(dest => dest.Instructors, opt => opt.MapFrom(src => src.SectionInstructors.Select(si => si.Instructor).ToList()))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.ProducerCompany, opt => opt.MapFrom(src => src.SectionAbout.ProducerCompany.Name));

        CreateMap<Section, GetStudentSectionListDto>().ReverseMap();

    }
}