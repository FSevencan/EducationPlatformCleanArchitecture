using Core.Application.Responses;

namespace Application.Features.Courses.Commands.Delete;

public class DeletedCourseResponse : IResponse
{
    public Guid Id { get; set; }
}