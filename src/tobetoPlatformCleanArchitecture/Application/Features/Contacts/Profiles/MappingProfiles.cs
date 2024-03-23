using Application.Features.Contacts.Commands.Create;
using Application.Features.Contacts.Commands.Delete;
using Application.Features.Contacts.Commands.Update;
using Application.Features.Contacts.Queries.GetById;
using Application.Features.Contacts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Contacts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Contact, CreateContactCommand>().ReverseMap();
        CreateMap<Contact, CreatedContactResponse>().ReverseMap();
        CreateMap<Contact, UpdateContactCommand>().ReverseMap();
        CreateMap<Contact, UpdatedContactResponse>().ReverseMap();
        CreateMap<Contact, DeleteContactCommand>().ReverseMap();
        CreateMap<Contact, DeletedContactResponse>().ReverseMap();
        CreateMap<Contact, GetByIdContactResponse>().ReverseMap();
        CreateMap<Contact, GetListContactListItemDto>().ReverseMap();
        CreateMap<IPaginate<Contact>, GetListResponse<GetListContactListItemDto>>().ReverseMap();
    }
}