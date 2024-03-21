using Core.Application.Responses;

namespace Application.Features.Likes.Queries.GetById;

public class GetByIdLikeResponse : IResponse
{
    public Guid Id { get; set; }
    public int StudentId { get; set; }
    public Guid SectionId { get; set; }
}