using Application.Features.ClassRooms.Commands.Create;
using Application.Features.ClassRooms.Commands.Delete;
using Application.Features.ClassRooms.Commands.Update;
using Application.Features.ClassRooms.Queries.GetById;
using Application.Features.ClassRooms.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ClassRooms.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ClassRoom, CreateClassRoomCommand>().ReverseMap();
        CreateMap<ClassRoom, CreatedClassRoomResponse>().ReverseMap();
        CreateMap<ClassRoom, UpdateClassRoomCommand>().ReverseMap();
        CreateMap<ClassRoom, UpdatedClassRoomResponse>().ReverseMap();
        CreateMap<ClassRoom, DeleteClassRoomCommand>().ReverseMap();
        CreateMap<ClassRoom, DeletedClassRoomResponse>().ReverseMap();
        CreateMap<ClassRoom, GetByIdClassRoomResponse>().ReverseMap();
        CreateMap<ClassRoom, GetListClassRoomListItemDto>().ReverseMap();
        CreateMap<IPaginate<ClassRoom>, GetListResponse<GetListClassRoomListItemDto>>().ReverseMap();
    }
}