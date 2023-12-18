using Application.Features.SectionAbouts.Commands.Create;
using Application.Features.SectionAbouts.Commands.Delete;
using Application.Features.SectionAbouts.Commands.Update;
using Application.Features.SectionAbouts.Queries.GetById;
using Application.Features.SectionAbouts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.SectionAbouts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<SectionAbout, CreateSectionAboutCommand>().ReverseMap();
        CreateMap<SectionAbout, CreatedSectionAboutResponse>().ReverseMap();
        CreateMap<SectionAbout, UpdateSectionAboutCommand>().ReverseMap();
        CreateMap<SectionAbout, UpdatedSectionAboutResponse>().ReverseMap();
        CreateMap<SectionAbout, DeleteSectionAboutCommand>().ReverseMap();
        CreateMap<SectionAbout, DeletedSectionAboutResponse>().ReverseMap();
        CreateMap<SectionAbout, GetByIdSectionAboutResponse>().ReverseMap();
        CreateMap<SectionAbout, GetListSectionAboutListItemDto>().ReverseMap();
        CreateMap<SectionAbout, GetSectionAboutDto>().ReverseMap();
        CreateMap<IPaginate<SectionAbout>, GetListResponse<GetListSectionAboutListItemDto>>().ReverseMap();
    }
}