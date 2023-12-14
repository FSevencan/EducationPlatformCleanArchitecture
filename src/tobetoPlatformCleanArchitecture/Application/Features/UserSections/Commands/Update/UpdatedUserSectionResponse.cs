using Core.Application.Responses;

namespace Application.Features.UserSections.Commands.Update;

public class UpdatedUserSectionResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid SectionId { get; set; }
    public int UserId { get; set; }
}