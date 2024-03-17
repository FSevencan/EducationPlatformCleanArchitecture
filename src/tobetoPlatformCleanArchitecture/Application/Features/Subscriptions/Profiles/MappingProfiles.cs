using Application.Features.Subscriptions.Commands.Create;
using Application.Features.Subscriptions.Commands.Delete;
using Application.Features.Subscriptions.Commands.Update;
using Application.Features.Subscriptions.Queries.GetById;
using Application.Features.Subscriptions.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.Subscriptions.Queries.GetSubscriptionsByUserId;

namespace Application.Features.Subscriptions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Subscription, CreateSubscriptionCommand>().ReverseMap();
        CreateMap<Subscription, CreatedSubscriptionResponse>().ReverseMap();
        CreateMap<Subscription, UpdateSubscriptionCommand>().ReverseMap();
        CreateMap<Subscription, UpdatedSubscriptionResponse>().ReverseMap();
        CreateMap<Subscription, DeleteSubscriptionCommand>().ReverseMap();
        CreateMap<Subscription, DeletedSubscriptionResponse>().ReverseMap();
        CreateMap<Subscription, GetByIdSubscriptionResponse>().ReverseMap();

        CreateMap<Subscription, GetSubscriptionByUserIdResponse>().ReverseMap();


        CreateMap<Subscription, GetListSubscriptionListItemDto>().ReverseMap();
        CreateMap<IPaginate<Subscription>, GetListResponse<GetListSubscriptionListItemDto>>().ReverseMap();
    }
}