using Core.Application.Responses;

namespace Application.Features.UserAnswers.Commands.Delete;

public class DeletedUserAnswerResponse : IResponse
{
    public Guid Id { get; set; }
}