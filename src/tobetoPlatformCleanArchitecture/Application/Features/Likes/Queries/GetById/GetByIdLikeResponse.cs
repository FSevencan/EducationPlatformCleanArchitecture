using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Likes.Queries.GetById;

public class GetByIdLikeResponse : IResponse
{
    public Guid Id { get; set; }
    public int StudentId { get; set; }
    public Guid SectionId { get; set; }
    public bool IsActive { get; set; }
    public Student Student { get; set; }
    public Section Section { get; set; }
}