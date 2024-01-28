using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Commands.Delete;
using Application.Features.Categories.Commands.Update;
using Application.Features.Categories.Queries.GetById;
using Application.Features.Categories.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.Categories.Queries.GetListCategorySections;
using Application.Features.Courses.Queries.GetList;
using Application.Features.Instructors.Queries.GetList;
using Application.Features.SectionAbouts.Queries.GetList;
using Application.Features.Sections.Queries.GetList;

namespace Application.Features.Categories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        CreateMap<Category, CreatedCategoryResponse>().ReverseMap();
        CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
        CreateMap<Category, UpdatedCategoryResponse>().ReverseMap();
        CreateMap<Category, DeleteCategoryCommand>().ReverseMap();
        CreateMap<Category, DeletedCategoryResponse>().ReverseMap();
        CreateMap<Category, GetByIdCategoryResponse>().ReverseMap();
        CreateMap<Category, GetListCategoryListItemDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<IPaginate<Category>, GetListResponse<GetListCategoryListItemDto>>().ReverseMap();
        CreateMap<IPaginate<Category>, GetListResponse<GetListCategorySectionsListItemDto>>().ReverseMap();
        CreateMap<Category, GetListCategorySectionsListItemDto>().ReverseMap();

        CreateMap<Category, GetListSectionListItemDto>().ReverseMap();




    }
}