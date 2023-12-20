using Application.Features.StudentSections.Commands.Create;
using Application.Features.StudentSections.Commands.Delete;
using Application.Features.StudentSections.Commands.Update;
using Application.Features.StudentSections.Queries.GetById;
using Application.Features.StudentSections.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.StudentSections.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<StudentSection, CreateStudentSectionCommand>().ReverseMap();
        CreateMap<StudentSection, CreatedStudentSectionResponse>().ReverseMap();
        CreateMap<StudentSection, UpdateStudentSectionCommand>().ReverseMap();
        CreateMap<StudentSection, UpdatedStudentSectionResponse>().ReverseMap();
        CreateMap<StudentSection, DeleteStudentSectionCommand>().ReverseMap();
        CreateMap<StudentSection, DeletedStudentSectionResponse>().ReverseMap();
        CreateMap<StudentSection, GetByIdStudentSectionResponse>().ReverseMap();
        CreateMap<StudentSection, GetListStudentSectionListItemDto>().ReverseMap();
        CreateMap<IPaginate<StudentSection>, GetListResponse<GetListStudentSectionListItemDto>>().ReverseMap();
    }
}