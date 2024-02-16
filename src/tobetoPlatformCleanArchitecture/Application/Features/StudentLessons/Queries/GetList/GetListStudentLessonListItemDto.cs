using Core.Application.Dtos;

namespace Application.Features.StudentLessons.Queries.GetList;

public class GetListStudentLessonListItemDto : IDto
{
    public Guid Id { get; set; }
    public int StudentId { get; set; }
    public Guid LessonId { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public bool IsCompleted { get; set; }
   
}