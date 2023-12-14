using Core.Application.Dtos;

namespace Application.Features.SectionCourses.Queries.GetList;

public class GetListSectionCourseListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid SectionId { get; set; }
}