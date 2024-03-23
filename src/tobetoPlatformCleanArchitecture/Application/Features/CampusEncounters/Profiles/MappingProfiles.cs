using Application.Features.CampusEncounters.Commands.Create;
using Application.Features.CampusEncounters.Commands.Delete;
using Application.Features.CampusEncounters.Commands.Update;
using Application.Features.CampusEncounters.Queries.GetById;
using Application.Features.CampusEncounters.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CampusEncounters.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CampusEncounter, CreateCampusEncounterCommand>().ReverseMap();
        CreateMap<CampusEncounter, CreatedCampusEncounterResponse>().ReverseMap();
        CreateMap<CampusEncounter, UpdateCampusEncounterCommand>().ReverseMap();
        CreateMap<CampusEncounter, UpdatedCampusEncounterResponse>().ReverseMap();
        CreateMap<CampusEncounter, DeleteCampusEncounterCommand>().ReverseMap();
        CreateMap<CampusEncounter, DeletedCampusEncounterResponse>().ReverseMap();
        CreateMap<CampusEncounter, GetByIdCampusEncounterResponse>().ReverseMap();
        CreateMap<CampusEncounter, GetListCampusEncounterListItemDto>().ReverseMap();
        CreateMap<IPaginate<CampusEncounter>, GetListResponse<GetListCampusEncounterListItemDto>>().ReverseMap();
    }
}