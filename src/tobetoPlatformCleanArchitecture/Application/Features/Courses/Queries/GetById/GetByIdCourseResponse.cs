using Core.Application.Responses;

namespace Application.Features.Courses.Queries.GetById;

public class GetByIdCourseResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public TimeSpan? TotalTime { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}