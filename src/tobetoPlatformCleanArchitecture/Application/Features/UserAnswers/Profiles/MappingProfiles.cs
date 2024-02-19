using Application.Features.UserAnswers.Commands.Create;
using Application.Features.UserAnswers.Commands.Delete;
using Application.Features.UserAnswers.Commands.Update;
using Application.Features.UserAnswers.Queries.GetById;
using Application.Features.UserAnswers.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.UserAnswers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserAnswer, CreateUserAnswerCommand>().ReverseMap();
        CreateMap<UserAnswer, CreatedUserAnswerResponse>().ReverseMap();
        CreateMap<UserAnswer, UpdateUserAnswerCommand>().ReverseMap();
        CreateMap<UserAnswer, UpdatedUserAnswerResponse>().ReverseMap();
        CreateMap<UserAnswer, DeleteUserAnswerCommand>().ReverseMap();
        CreateMap<UserAnswer, DeletedUserAnswerResponse>().ReverseMap();
        CreateMap<UserAnswer, GetByIdUserAnswerResponse>().ReverseMap();
        CreateMap<UserAnswer, GetListUserAnswerListItemDto>().ReverseMap();
        CreateMap<IPaginate<UserAnswer>, GetListResponse<GetListUserAnswerListItemDto>>().ReverseMap();
    }
}