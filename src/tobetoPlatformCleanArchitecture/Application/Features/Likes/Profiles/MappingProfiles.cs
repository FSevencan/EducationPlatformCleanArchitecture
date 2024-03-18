using Application.Features.Likes.Commands.Create;
using Application.Features.Likes.Commands.Delete;
using Application.Features.Likes.Commands.Update;
using Application.Features.Likes.Queries.GetById;
using Application.Features.Likes.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.Likes.Queries.CheckLikeStatus;

namespace Application.Features.Likes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Like, CreateLikeCommand>().ReverseMap();
        CreateMap<Like, CreatedLikeResponse>().ReverseMap();
        CreateMap<Like, UpdateLikeCommand>().ReverseMap();
        CreateMap<Like, UpdatedLikeResponse>().ReverseMap();
        CreateMap<Like, DeleteLikeCommand>().ReverseMap();
        CreateMap<Like, DeletedLikeResponse>().ReverseMap();
        CreateMap<Like, GetByIdLikeResponse>().ReverseMap();
        CreateMap<Like, GetListLikeListItemDto>().ReverseMap();
        CreateMap<IPaginate<Like>, GetListResponse<GetListLikeListItemDto>>().ReverseMap();
        CreateMap<Like, CheckLikeStatusResponse>();

        CreateMap<Like, CheckLikeStatusResponse>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive)).ReverseMap();
    }
}