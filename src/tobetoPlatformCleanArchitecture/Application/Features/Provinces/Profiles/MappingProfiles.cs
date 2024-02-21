using Application.Features.Provinces.Commands.Create;
using Application.Features.Provinces.Commands.Delete;
using Application.Features.Provinces.Commands.Update;
using Application.Features.Provinces.Queries.GetById;
using Application.Features.Provinces.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Provinces.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Province, CreateProvinceCommand>().ReverseMap();
        CreateMap<Province, CreatedProvinceResponse>().ReverseMap();
        CreateMap<Province, UpdateProvinceCommand>().ReverseMap();
        CreateMap<Province, UpdatedProvinceResponse>().ReverseMap();
        CreateMap<Province, DeleteProvinceCommand>().ReverseMap();
        CreateMap<Province, DeletedProvinceResponse>().ReverseMap();
        CreateMap<Province, GetByIdProvinceResponse>().ReverseMap();
        CreateMap<Province, GetListProvinceListItemDto>().ReverseMap();
        CreateMap<IPaginate<Province>, GetListResponse<GetListProvinceListItemDto>>().ReverseMap();
    }
}