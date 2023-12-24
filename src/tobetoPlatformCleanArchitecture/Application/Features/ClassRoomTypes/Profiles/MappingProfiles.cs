using Application.Features.ClassRoomTypes.Commands.Create;
using Application.Features.ClassRoomTypes.Commands.Delete;
using Application.Features.ClassRoomTypes.Commands.Update;
using Application.Features.ClassRoomTypes.Queries.GetById;
using Application.Features.ClassRoomTypes.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ClassRoomTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ClassRoomType, CreateClassRoomTypeCommand>().ReverseMap();
        CreateMap<ClassRoomType, CreatedClassRoomTypeResponse>().ReverseMap();
        CreateMap<ClassRoomType, UpdateClassRoomTypeCommand>().ReverseMap();
        CreateMap<ClassRoomType, UpdatedClassRoomTypeResponse>().ReverseMap();
        CreateMap<ClassRoomType, DeleteClassRoomTypeCommand>().ReverseMap();
        CreateMap<ClassRoomType, DeletedClassRoomTypeResponse>().ReverseMap();
        CreateMap<ClassRoomType, GetByIdClassRoomTypeResponse>().ReverseMap();
        CreateMap<ClassRoomType, GetListClassRoomTypeListItemDto>().ReverseMap();
        CreateMap<IPaginate<ClassRoomType>, GetListResponse<GetListClassRoomTypeListItemDto>>().ReverseMap();
    }
}