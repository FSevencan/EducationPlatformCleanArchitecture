using Core.Application.Dtos;
using Domain.Entities;

namespace Application.Features.SectionCourses.Queries.GetList;

public class GetListSectionCourseListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid SectionId { get; set; }
    public Section Section { get; set; }
    public Course Course { get; set; }
}