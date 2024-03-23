using Application.Features.Questions.Commands.Create;
using Application.Features.Questions.Commands.Delete;
using Application.Features.Questions.Commands.Update;
using Application.Features.Questions.Queries.GetById;
using Application.Features.Questions.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.Exams.Queries.GetByIdForQuestions;

namespace Application.Features.Questions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Question, CreateQuestionCommand>().ReverseMap();
        CreateMap<Question, CreatedQuestionResponse>().ReverseMap();
        CreateMap<Question, UpdateQuestionCommand>().ReverseMap();
        CreateMap<Question, UpdatedQuestionResponse>().ReverseMap();
        CreateMap<Question, DeleteQuestionCommand>().ReverseMap();
        CreateMap<Question, DeletedQuestionResponse>().ReverseMap();
        CreateMap<Question, GetByIdQuestionResponse>().ReverseMap();
        CreateMap<Question, GetListQuestionListItemDto>().ReverseMap();
        CreateMap<IPaginate<Question>, GetListResponse<GetListQuestionListItemDto>>().ReverseMap();

        CreateMap<Question, GetListQuestionByExamIdDto>()
            .ForMember(dest=> dest.Choices, opt=>opt.MapFrom(q=> q.Choices))
            .ReverseMap();

        CreateMap<IPaginate<Question>, GetListResponse<GetListQuestionByExamIdDto>>()
           .ReverseMap();
    }
}