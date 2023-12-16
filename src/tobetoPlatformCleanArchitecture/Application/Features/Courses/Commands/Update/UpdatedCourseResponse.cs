using Core.Application.Responses;

namespace Application.Features.Courses.Commands.Update;

public class UpdatedCourseResponse : IResponse
{
    public Guid Id { get; set; }
    public double? TotalTime { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}