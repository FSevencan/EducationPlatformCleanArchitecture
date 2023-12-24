using Application.Features.ClassRoomTypeSections.Commands.Create;
using Application.Features.ClassRoomTypeSections.Commands.Delete;
using Application.Features.ClassRoomTypeSections.Commands.Update;
using Application.Features.ClassRoomTypeSections.Queries.GetById;
using Application.Features.ClassRoomTypeSections.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ClassRoomTypeSections.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ClassRoomTypeSection, CreateClassRoomTypeSectionCommand>().ReverseMap();
        CreateMap<ClassRoomTypeSection, CreatedClassRoomTypeSectionResponse>().ReverseMap();
        CreateMap<ClassRoomTypeSection, UpdateClassRoomTypeSectionCommand>().ReverseMap();
        CreateMap<ClassRoomTypeSection, UpdatedClassRoomTypeSectionResponse>().ReverseMap();
        CreateMap<ClassRoomTypeSection, DeleteClassRoomTypeSectionCommand>().ReverseMap();
        CreateMap<ClassRoomTypeSection, DeletedClassRoomTypeSectionResponse>().ReverseMap();
        CreateMap<ClassRoomTypeSection, GetByIdClassRoomTypeSectionResponse>().ReverseMap();
        CreateMap<ClassRoomTypeSection, GetListClassRoomTypeSectionListItemDto>().ReverseMap();
        CreateMap<IPaginate<ClassRoomTypeSection>, GetListResponse<GetListClassRoomTypeSectionListItemDto>>().ReverseMap();
    }
}