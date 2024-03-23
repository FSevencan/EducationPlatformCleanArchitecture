using Core.Application.Responses;

namespace Application.Features.Choices.Commands.Delete;

public class DeletedChoiceResponse : IResponse
{
    public Guid Id { get; set; }
}