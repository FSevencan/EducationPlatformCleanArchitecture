using Core.Application.Responses;

namespace Application.Features.UserSections.Commands.Delete;

public class DeletedUserSectionResponse : IResponse
{
    public Guid Id { get; set; }
}