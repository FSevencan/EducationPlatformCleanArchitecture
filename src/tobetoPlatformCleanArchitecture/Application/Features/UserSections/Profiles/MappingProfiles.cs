using Application.Features.UserSections.Commands.Create;
using Application.Features.UserSections.Commands.Delete;
using Application.Features.UserSections.Commands.Update;
using Application.Features.UserSections.Queries.GetById;
using Application.Features.UserSections.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.UserSections.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserSection, CreateUserSectionCommand>().ReverseMap();
        CreateMap<UserSection, CreatedUserSectionResponse>().ReverseMap();
        CreateMap<UserSection, UpdateUserSectionCommand>().ReverseMap();
        CreateMap<UserSection, UpdatedUserSectionResponse>().ReverseMap();
        CreateMap<UserSection, DeleteUserSectionCommand>().ReverseMap();
        CreateMap<UserSection, DeletedUserSectionResponse>().ReverseMap();
        CreateMap<UserSection, GetByIdUserSectionResponse>().ReverseMap();
        CreateMap<UserSection, GetListUserSectionListItemDto>().ReverseMap();
        CreateMap<IPaginate<UserSection>, GetListResponse<GetListUserSectionListItemDto>>().ReverseMap();
    }
}