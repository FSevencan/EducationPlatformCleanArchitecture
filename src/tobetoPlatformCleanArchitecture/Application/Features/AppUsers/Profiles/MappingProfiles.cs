using Application.Features.AppUsers.Commands.Create;
using Application.Features.AppUsers.Commands.Delete;
using Application.Features.AppUsers.Commands.Update;
using Application.Features.AppUsers.Queries.GetById;
using Application.Features.AppUsers.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.AppUsers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AppUser, CreateAppUserCommand>().ReverseMap();
        CreateMap<AppUser, CreatedAppUserResponse>().ReverseMap();
        CreateMap<AppUser, UpdateAppUserCommand>().ReverseMap();
        CreateMap<AppUser, UpdatedAppUserResponse>().ReverseMap();
        CreateMap<AppUser, DeleteAppUserCommand>().ReverseMap();
        CreateMap<AppUser, DeletedAppUserResponse>().ReverseMap();
        CreateMap<AppUser, GetByIdAppUserResponse>().ReverseMap();
        CreateMap<AppUser, GetListAppUserListItemDto>().ReverseMap();
        CreateMap<IPaginate<AppUser>, GetListResponse<GetListAppUserListItemDto>>().ReverseMap();
    }
}