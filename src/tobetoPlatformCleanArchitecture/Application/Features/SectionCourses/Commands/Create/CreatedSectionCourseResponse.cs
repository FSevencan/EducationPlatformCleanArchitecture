using Core.Application.Responses;

namespace Application.Features.SectionCourses.Commands.Create;

public class CreatedSectionCourseResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid SectionId { get; set; }
}