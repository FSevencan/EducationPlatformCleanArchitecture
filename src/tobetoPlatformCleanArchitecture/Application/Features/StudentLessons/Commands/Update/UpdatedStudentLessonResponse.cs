using Core.Application.Responses;

namespace Application.Features.StudentLessons.Commands.Update;

public class UpdatedStudentLessonResponse : IResponse
{
    public Guid Id { get; set; }
    public int StudentId { get; set; }
    public Guid LessonId { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public bool IsCompleted { get; set; }
   
}