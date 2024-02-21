using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Exams.Queries.GetByIdForQuestions;

public class GetByIdExamForQuestionsResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Duration { get; set; }
    public int QuestionCount { get; set; }
    public string QuestionType { get; set; }   

    public ICollection<GetListQuestionByExamIdDto> Questions { get; set; }
}