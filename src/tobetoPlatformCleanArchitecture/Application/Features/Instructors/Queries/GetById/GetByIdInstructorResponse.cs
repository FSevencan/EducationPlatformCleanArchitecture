using Core.Application.Responses;

namespace Application.Features.Instructors.Queries.GetById;

public class GetByIdInstructorResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? ImageUrl { get; set; }
}