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
        CreateMap<StudentClassRoom, CreateStudentClassRoomCommand>().ReverseMap();
        CreateMap<StudentClassRoom, CreatedStudentClassRoomResponse>().ReverseMap();
        CreateMap<StudentClassRoom, UpdateStudentClassRoomCommand>().ReverseMap();
        CreateMap<StudentClassRoom, UpdatedStudentClassRoomResponse>().ReverseMap();
        CreateMap<StudentClassRoom, DeleteStudentClassRoomCommand>().ReverseMap();
        CreateMap<StudentClassRoom, DeletedStudentClassRoomResponse>().ReverseMap();
        CreateMap<StudentClassRoom, GetByIdStudentClassRoomResponse>().ReverseMap();
        CreateMap<StudentClassRoom, GetListStudentClassRoomListItemDto>().ReverseMap();
        CreateMap<IPaginate<StudentClassRoom>, GetListResponse<GetListStudentClassRoomListItemDto>>().ReverseMap();
    }
}