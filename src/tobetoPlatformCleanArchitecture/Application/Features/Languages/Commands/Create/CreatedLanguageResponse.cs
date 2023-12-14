using Core.Application.Responses;

namespace Application.Features.Languages.Commands.Create;

public class CreatedLanguageResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}