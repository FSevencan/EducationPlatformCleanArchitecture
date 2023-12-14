using Application.Features.ApplicationEducations.Commands.Create;
using Application.Features.ApplicationEducations.Commands.Delete;
using Application.Features.ApplicationEducations.Commands.Update;
using Application.Features.ApplicationEducations.Queries.GetById;
using Application.Features.ApplicationEducations.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ApplicationEducations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ApplicationEducation, CreateApplicationEducationCommand>().ReverseMap();
        CreateMap<ApplicationEducation, CreatedApplicationEducationResponse>().ReverseMap();
        CreateMap<ApplicationEducation, UpdateApplicationEducationCommand>().ReverseMap();
        CreateMap<ApplicationEducation, UpdatedApplicationEducationResponse>().ReverseMap();
        CreateMap<ApplicationEducation, DeleteApplicationEducationCommand>().ReverseMap();
        CreateMap<ApplicationEducation, DeletedApplicationEducationResponse>().ReverseMap();
        CreateMap<ApplicationEducation, GetByIdApplicationEducationResponse>().ReverseMap();
        CreateMap<ApplicationEducation, GetListApplicationEducationListItemDto>().ReverseMap();
        CreateMap<IPaginate<ApplicationEducation>, GetListResponse<GetListApplicationEducationListItemDto>>().ReverseMap();
    }
}