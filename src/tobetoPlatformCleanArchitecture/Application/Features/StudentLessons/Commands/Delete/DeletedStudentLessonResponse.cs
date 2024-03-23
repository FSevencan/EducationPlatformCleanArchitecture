using Core.Application.Responses;

namespace Application.Features.StudentLessons.Commands.Delete;

public class DeletedStudentLessonResponse : IResponse
{
    public Guid Id { get; set; }
}