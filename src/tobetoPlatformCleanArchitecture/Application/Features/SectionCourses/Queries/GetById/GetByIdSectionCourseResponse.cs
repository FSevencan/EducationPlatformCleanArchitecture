using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.SectionCourses.Queries.GetById;

public class GetByIdSectionCourseResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid SectionId { get; set; }
    public Section Section { get; set; }
    public Course Course { get; set; }
}