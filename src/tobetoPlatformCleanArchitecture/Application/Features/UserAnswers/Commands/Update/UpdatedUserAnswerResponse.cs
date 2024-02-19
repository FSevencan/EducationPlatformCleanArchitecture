using Core.Application.Responses;
using Core.Security.Entities;
using Domain.Entities;

namespace Application.Features.UserAnswers.Commands.Update;

public class UpdatedUserAnswerResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public Guid ChoiceId { get; set; }
    public Guid QuestionId { get; set; }
    public string AnswerText { get; set; }
    public Question Question { get; set; }
    public User User { get; set; }
    public Choice Choice { get; set; }
}