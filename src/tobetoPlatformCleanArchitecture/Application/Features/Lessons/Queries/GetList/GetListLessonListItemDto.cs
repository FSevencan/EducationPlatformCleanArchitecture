using Core.Application.Dtos;

namespace Application.Features.Lessons.Queries.GetList;

public class GetListLessonListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid ProducerCompanyId { get; set; }
    public Guid CourseId { get; set; }
    public Guid LanguageId { get; set; }
    public string Name { get; set; }
    public double? Time { get; set; } //TimeSpan?? d�zenlendi
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
}