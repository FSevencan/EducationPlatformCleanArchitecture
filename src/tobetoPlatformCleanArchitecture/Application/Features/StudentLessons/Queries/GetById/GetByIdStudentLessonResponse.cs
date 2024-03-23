using Core.Application.Responses;

namespace Application.Features.StudentLessons.Queries.GetById;

public class GetByIdStudentLessonResponse : IResponse
{
    public Guid Id { get; set; }
    public int StudentId { get; set; }
    public Guid LessonId { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public bool IsCompleted { get; set; }
    
}