using Core.Application.Responses;

namespace Application.Features.Sections.Commands.Delete;

public class DeletedSectionResponse : IResponse
{
    public Guid Id { get; set; }
}