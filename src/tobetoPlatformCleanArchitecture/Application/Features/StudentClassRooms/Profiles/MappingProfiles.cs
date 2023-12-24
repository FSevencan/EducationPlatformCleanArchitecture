using Application.Features.StudentClassRooms.Commands.Create;
using Application.Features.StudentClassRooms.Commands.Delete;
using Application.Features.StudentClassRooms.Commands.Update;
using Application.Features.StudentClassRooms.Queries.GetById;
using Application.Features.StudentClassRooms.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.StudentClassRooms.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ClassRoomTypeSection, CreateStudentClassRoomCommand>().ReverseMap();
        CreateMap<ClassRoomTypeSection, CreatedStudentClassRoomResponse>().ReverseMap();
        CreateMap<ClassRoomTypeSection, UpdateStudentClassRoomCommand>().ReverseMap();
        CreateMap<ClassRoomTypeSection, UpdatedStudentClassRoomResponse>().ReverseMap();
        CreateMap<ClassRoomTypeSection, DeleteStudentClassRoomCommand>().ReverseMap();
        CreateMap<ClassRoomTypeSection, DeletedStudentClassRoomResponse>().ReverseMap();
        CreateMap<ClassRoomTypeSection, GetByIdStudentClassRoomResponse>().ReverseMap();
        CreateMap<ClassRoomTypeSection, GetListStudentClassRoomListItemDto>().ReverseMap();
        CreateMap<IPaginate<ClassRoomTypeSection>, GetListResponse<GetListStudentClassRoomListItemDto>>().ReverseMap();
    }
}