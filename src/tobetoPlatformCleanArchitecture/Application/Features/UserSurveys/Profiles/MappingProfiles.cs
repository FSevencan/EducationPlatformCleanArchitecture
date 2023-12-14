using Application.Features.UserSurveys.Commands.Create;
using Application.Features.UserSurveys.Commands.Delete;
using Application.Features.UserSurveys.Commands.Update;
using Application.Features.UserSurveys.Queries.GetById;
using Application.Features.UserSurveys.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.UserSurveys.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserSurvey, CreateUserSurveyCommand>().ReverseMap();
        CreateMap<UserSurvey, CreatedUserSurveyResponse>().ReverseMap();
        CreateMap<UserSurvey, UpdateUserSurveyCommand>().ReverseMap();
        CreateMap<UserSurvey, UpdatedUserSurveyResponse>().ReverseMap();
        CreateMap<UserSurvey, DeleteUserSurveyCommand>().ReverseMap();
        CreateMap<UserSurvey, DeletedUserSurveyResponse>().ReverseMap();
        CreateMap<UserSurvey, GetByIdUserSurveyResponse>().ReverseMap();
        CreateMap<UserSurvey, GetListUserSurveyListItemDto>().ReverseMap();
        CreateMap<IPaginate<UserSurvey>, GetListResponse<GetListUserSurveyListItemDto>>().ReverseMap();
    }
}