using Core.Application.Responses;

namespace Application.Features.Languages.Commands.Delete;

public class DeletedLanguageResponse : IResponse
{
    public Guid Id { get; set; }
}