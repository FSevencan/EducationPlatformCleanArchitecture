using Application.Features.Languages.Commands.Create;
using Application.Features.Languages.Commands.Delete;
using Application.Features.Languages.Commands.Update;
using Application.Features.Languages.Queries.GetById;
using Application.Features.Languages.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Languages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Language, CreateLanguageCommand>().ReverseMap();
        CreateMap<Language, CreatedLanguageResponse>().ReverseMap();
        CreateMap<Language, UpdateLanguageCommand>().ReverseMap();
        CreateMap<Language, UpdatedLanguageResponse>().ReverseMap();
        CreateMap<Language, DeleteLanguageCommand>().ReverseMap();
        CreateMap<Language, DeletedLanguageResponse>().ReverseMap();
        CreateMap<Language, GetByIdLanguageResponse>().ReverseMap();
        CreateMap<Language, GetListLanguageListItemDto>().ReverseMap();
        CreateMap<IPaginate<Language>, GetListResponse<GetListLanguageListItemDto>>().ReverseMap();
    }
}