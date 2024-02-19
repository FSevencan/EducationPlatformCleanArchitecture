using Application.Features.Questions.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Questions.Constants.QuestionsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Questions.Queries.GetListByExamId;

public class GetListQuestionByExamIdQuery : IRequest<GetListResponse<GetListQuestionByExamIdDto>>/*, ISecuredRequest*/, ICachableRequest
{
    public Guid ExamId { get; set; }
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListQuestionsByExamId({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetQuestionsByExamId";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListQuestionByExamIdQueryHandler : IRequestHandler<GetListQuestionByExamIdQuery, GetListResponse<GetListQuestionByExamIdDto>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetListQuestionByExamIdQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListQuestionByExamIdDto>> Handle(GetListQuestionByExamIdQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Question> questions = await _questionRepository.GetListAsync(
                predicate: q=>q.ExamId == request.ExamId,
                include: q => q.Include(c=>c.Choices),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListQuestionByExamIdDto> response = _mapper.Map<GetListResponse<GetListQuestionByExamIdDto>>(questions);
            return response;
        }
    }
}