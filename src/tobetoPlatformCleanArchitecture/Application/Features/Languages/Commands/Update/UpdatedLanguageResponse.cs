using Core.Application.Responses;

namespace Application.Features.Languages.Commands.Update;

public class UpdatedLanguageResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}