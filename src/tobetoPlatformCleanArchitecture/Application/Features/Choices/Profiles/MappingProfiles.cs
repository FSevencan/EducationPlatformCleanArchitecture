using Application.Features.Choices.Commands.Create;
using Application.Features.Choices.Commands.Delete;
using Application.Features.Choices.Commands.Update;
using Application.Features.Choices.Queries.GetById;
using Application.Features.Choices.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Choices.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Choice, CreateChoiceCommand>().ReverseMap();
        CreateMap<Choice, CreatedChoiceResponse>().ReverseMap();
        CreateMap<Choice, UpdateChoiceCommand>().ReverseMap();
        CreateMap<Choice, UpdatedChoiceResponse>().ReverseMap();
        CreateMap<Choice, DeleteChoiceCommand>().ReverseMap();
        CreateMap<Choice, DeletedChoiceResponse>().ReverseMap();
        CreateMap<Choice, GetByIdChoiceResponse>().ReverseMap();
        CreateMap<Choice, GetListChoiceListItemDto>().ReverseMap();
        CreateMap<IPaginate<Choice>, GetListResponse<GetListChoiceListItemDto>>().ReverseMap();
    }
}