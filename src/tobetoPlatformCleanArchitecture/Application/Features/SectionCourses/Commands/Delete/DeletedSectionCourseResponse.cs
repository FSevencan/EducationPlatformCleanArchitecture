using Core.Application.Responses;

namespace Application.Features.SectionCourses.Commands.Delete;

public class DeletedSectionCourseResponse : IResponse
{
    public Guid Id { get; set; }
}