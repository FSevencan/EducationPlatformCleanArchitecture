using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Questions.Commands.Update;

public class UpdatedQuestionResponse : IResponse
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public Guid ExamId { get; set; }
   
}