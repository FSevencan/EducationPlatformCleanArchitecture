using Core.Application.Responses;
using Core.Security.Entities;
using Domain.Entities;

namespace Application.Features.UserAnswers.Commands.Create;

public class CreatedUserAnswerResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public Guid ExamId { get; set; }

    public int CorrectCount { get; set; }
    public int WrongCount { get; set; }
    public int EmptyCount { get; set; }
    public int? TotalScore { get; set; }
}