using Application.Features.Instructors.Commands.Create;
using Application.Features.Instructors.Commands.Delete;
using Application.Features.Instructors.Commands.Update;
using Application.Features.Instructors.Queries.GetById;
using Application.Features.Instructors.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.Sections.Queries.GetList;
using Core.Application.Dtos;

namespace Application.Features.Instructors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Instructor, CreateInstructorCommand>().ReverseMap();
        CreateMap<Instructor, CreatedInstructorResponse>().ReverseMap();
        CreateMap<Instructor, UpdateInstructorCommand>().ReverseMap();
        CreateMap<Instructor, UpdatedInstructorResponse>().ReverseMap();
        CreateMap<Instructor, DeleteInstructorCommand>().ReverseMap();
        CreateMap<Instructor, DeletedInstructorResponse>().ReverseMap();
        CreateMap<Instructor, GetByIdInstructorResponse>().ReverseMap();
        CreateMap<Instructor, GetListInstructorListItemDto>().ReverseMap();
        CreateMap<Instructor, GetListInstructorDto>().ReverseMap();
        CreateMap<Instructor, UpdateInstructorDto>().ReverseMap();
        CreateMap<IPaginate<Instructor>, GetListResponse<GetListInstructorListItemDto>>().ReverseMap();
        CreateMap<IPaginate<Instructor>, GetListResponse<GetListInstructorsSectionListDto>>().ReverseMap();

        CreateMap<Instructor, GetListInstructorListItemDto>()
            .ForMember(dest => dest.Sections, opt => opt.MapFrom(src => src.SectionInstructors
            .Select(si => si.Section).ToList())); //?? new List<Section>()));


    }
}