using Application.Features.Exams.Constants;
using Application.Features.Exams.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Exams.Constants.ExamsOperationClaims;
using Microsoft.EntityFrameworkCore;
using Application.Features.Exams.Queries.GetById;

namespace Application.Features.Exams.Queries.GetByIdForQuestions;

public class GetByIdExamForQuestionsQuery : IRequest<GetByIdExamForQuestionsResponse>/*, ISecuredRequest*/
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdExamForQuestionsQueryHandler : IRequestHandler<GetByIdExamForQuestionsQuery, GetByIdExamForQuestionsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExamRepository _examRepository;
        private readonly ExamBusinessRules _examBusinessRules;

        public GetByIdExamForQuestionsQueryHandler(IMapper mapper, IExamRepository examRepository, ExamBusinessRules examBusinessRules)
        {
            _mapper = mapper;
            _examRepository = examRepository;
            _examBusinessRules = examBusinessRules;
        }

        public async Task<GetByIdExamForQuestionsResponse> Handle(GetByIdExamForQuestionsQuery request, CancellationToken cancellationToken)
        {
            Exam? exam = await _examRepository.GetAsync(predicate: e => e.Id == request.Id,
                include: exam => exam
                .Include(e => e.Questions)
                .ThenInclude(q => q.Choices),

                cancellationToken: cancellationToken);
            await _examBusinessRules.ExamShouldExistWhenSelected(exam);

            GetByIdExamForQuestionsResponse response = _mapper.Map<GetByIdExamForQuestionsResponse>(exam);
            return response;
        }
    }
}