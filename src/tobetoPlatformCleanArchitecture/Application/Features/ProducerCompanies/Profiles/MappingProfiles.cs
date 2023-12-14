using Application.Features.ProducerCompanies.Commands.Create;
using Application.Features.ProducerCompanies.Commands.Delete;
using Application.Features.ProducerCompanies.Commands.Update;
using Application.Features.ProducerCompanies.Queries.GetById;
using Application.Features.ProducerCompanies.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ProducerCompanies.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProducerCompany, CreateProducerCompanyCommand>().ReverseMap();
        CreateMap<ProducerCompany, CreatedProducerCompanyResponse>().ReverseMap();
        CreateMap<ProducerCompany, UpdateProducerCompanyCommand>().ReverseMap();
        CreateMap<ProducerCompany, UpdatedProducerCompanyResponse>().ReverseMap();
        CreateMap<ProducerCompany, DeleteProducerCompanyCommand>().ReverseMap();
        CreateMap<ProducerCompany, DeletedProducerCompanyResponse>().ReverseMap();
        CreateMap<ProducerCompany, GetByIdProducerCompanyResponse>().ReverseMap();
        CreateMap<ProducerCompany, GetListProducerCompanyListItemDto>().ReverseMap();
        CreateMap<IPaginate<ProducerCompany>, GetListResponse<GetListProducerCompanyListItemDto>>().ReverseMap();
    }
}