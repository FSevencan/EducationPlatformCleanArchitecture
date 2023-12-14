using Core.Application.Dtos;

namespace Application.Features.UserSections.Queries.GetList;

public class GetListUserSectionListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid SectionId { get; set; }
    public int UserId { get; set; }
}