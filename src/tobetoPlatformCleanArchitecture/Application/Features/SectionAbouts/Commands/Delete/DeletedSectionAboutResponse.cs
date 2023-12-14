using Core.Application.Responses;

namespace Application.Features.SectionAbouts.Commands.Delete;

public class DeletedSectionAboutResponse : IResponse
{
    public Guid Id { get; set; }
}