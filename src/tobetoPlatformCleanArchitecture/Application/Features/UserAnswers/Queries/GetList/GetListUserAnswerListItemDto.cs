using Core.Application.Dtos;
using Core.Security.Entities;
using Domain.Entities;

namespace Application.Features.UserAnswers.Queries.GetList;

public class GetListUserAnswerListItemDto : IDto
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public Guid ExamId { get; set; }
    public int CorrectCount { get; set; }
    public int WrongCount { get; set; }
    public int EmptyCount { get; set; }
    public int? TotalScore { get; set; }
}