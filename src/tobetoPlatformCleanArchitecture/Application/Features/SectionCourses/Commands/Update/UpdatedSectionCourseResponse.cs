using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.SectionCourses.Commands.Update;

public class UpdatedSectionCourseResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid SectionId { get; set; }
    public Section Section { get; set; }
    public Course Course { get; set; }
}