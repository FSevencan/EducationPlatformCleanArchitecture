using Core.Application.Responses;

namespace Application.Features.Lessons.Commands.Update;

public class UpdatedLessonResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public string Name { get; set; }
    public string VideoUrl { get; set; }
    public double Time { get; set; }
    
}