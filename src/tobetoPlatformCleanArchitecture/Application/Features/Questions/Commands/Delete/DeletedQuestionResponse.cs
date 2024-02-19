using Core.Application.Responses;

namespace Application.Features.Questions.Commands.Delete;

public class DeletedQuestionResponse : IResponse
{
    public Guid Id { get; set; }
}