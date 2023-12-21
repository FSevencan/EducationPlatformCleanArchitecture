using Application.Features.Lessons.Queries.GetList;
using Core.Application.Dtos;
using Domain.Entities;

namespace Application.Features.Courses.Queries.GetList;

public class GetListCourseListItemDto : IDto
{
    public Guid Id { get; set; }
    public double? TotalTime { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<GetListLessonListItemDto> Lessons { get; set; }
}