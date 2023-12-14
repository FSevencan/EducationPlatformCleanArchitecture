using Application.Features.Sections.Commands.Create;
using Application.Features.Sections.Commands.Delete;
using Application.Features.Sections.Commands.Update;
using Application.Features.Sections.Queries.GetById;
using Application.Features.Sections.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

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
        CreateMap<Section, GetByIdSectionResponse>().ReverseMap();
        CreateMap<Section, GetListSectionListItemDto>().ReverseMap();
        CreateMap<IPaginate<Section>, GetListResponse<GetListSectionListItemDto>>().ReverseMap();
    }
}