using Application.Features.Skills.Commands.Create;
using Application.Features.Skills.Commands.Delete;
using Application.Features.Skills.Commands.Update;
using Application.Features.Skills.Queries.GetById;
using Application.Features.Skills.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Skills.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Skill, CreateSkillCommand>().ReverseMap();
        CreateMap<Skill, CreatedSkillResponse>().ReverseMap();
        CreateMap<Skill, UpdateSkillCommand>().ReverseMap();
        CreateMap<Skill, UpdatedSkillResponse>().ReverseMap();
        CreateMap<Skill, DeleteSkillCommand>().ReverseMap();
        CreateMap<Skill, DeletedSkillResponse>().ReverseMap();
        CreateMap<Skill, GetByIdSkillResponse>().ReverseMap();
        CreateMap<Skill, GetListSkillListItemDto>().ReverseMap();
        CreateMap<IPaginate<Skill>, GetListResponse<GetListSkillListItemDto>>().ReverseMap();
    }
}