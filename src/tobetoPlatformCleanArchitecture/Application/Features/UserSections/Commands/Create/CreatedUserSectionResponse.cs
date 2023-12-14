using Core.Application.Responses;

namespace Application.Features.UserSections.Commands.Create;

public class CreatedUserSectionResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid SectionId { get; set; }
    public int UserId { get; set; }
}