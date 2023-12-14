using Application.Features.SectionInstructors.Commands.Create;
using Application.Features.SectionInstructors.Commands.Delete;
using Application.Features.SectionInstructors.Commands.Update;
using Application.Features.SectionInstructors.Queries.GetById;
using Application.Features.SectionInstructors.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.SectionInstructors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<SectionInstructor, CreateSectionInstructorCommand>().ReverseMap();
        CreateMap<SectionInstructor, CreatedSectionInstructorResponse>().ReverseMap();
        CreateMap<SectionInstructor, UpdateSectionInstructorCommand>().ReverseMap();
        CreateMap<SectionInstructor, UpdatedSectionInstructorResponse>().ReverseMap();
        CreateMap<SectionInstructor, DeleteSectionInstructorCommand>().ReverseMap();
        CreateMap<SectionInstructor, DeletedSectionInstructorResponse>().ReverseMap();
        CreateMap<SectionInstructor, GetByIdSectionInstructorResponse>().ReverseMap();
        CreateMap<SectionInstructor, GetListSectionInstructorListItemDto>().ReverseMap();
        CreateMap<IPaginate<SectionInstructor>, GetListResponse<GetListSectionInstructorListItemDto>>().ReverseMap();
    }
}