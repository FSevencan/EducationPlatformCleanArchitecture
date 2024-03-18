using Core.Application.Dtos;

namespace Application.Features.Likes.Queries.GetList;

public class GetListLikeListItemDto : IDto
{
    public Guid Id { get; set; }
    public int StudentId { get; set; }
    public Guid SectionId { get; set; }
    public bool IsActive { get; set; }
}