using Core.Application.Dtos;
using Domain.Entities;

namespace Application.Features.Choices.Queries.GetList;

public class GetListChoiceListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
   
}