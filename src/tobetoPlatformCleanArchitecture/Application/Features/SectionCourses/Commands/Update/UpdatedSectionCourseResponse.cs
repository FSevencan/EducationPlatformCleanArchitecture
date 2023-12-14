using Core.Application.Responses;

namespace Application.Features.SectionCourses.Commands.Update;

public class UpdatedSectionCourseResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid SectionId { get; set; }
}