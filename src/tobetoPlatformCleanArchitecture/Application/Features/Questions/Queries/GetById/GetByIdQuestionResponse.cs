using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Questions.Queries.GetById;

public class GetByIdQuestionResponse : IResponse
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public Guid ExamId { get; set; }
  
}