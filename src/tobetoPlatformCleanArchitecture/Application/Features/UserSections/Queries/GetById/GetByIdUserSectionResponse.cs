using Core.Application.Responses;

namespace Application.Features.UserSections.Queries.GetById;

public class GetByIdUserSectionResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid SectionId { get; set; }
    public int UserId { get; set; }
}