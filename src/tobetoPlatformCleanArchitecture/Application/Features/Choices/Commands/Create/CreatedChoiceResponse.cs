using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Choices.Commands.Create;

public class CreatedChoiceResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
}