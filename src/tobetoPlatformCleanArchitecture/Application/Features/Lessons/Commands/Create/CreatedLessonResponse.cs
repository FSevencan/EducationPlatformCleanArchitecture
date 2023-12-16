using Core.Application.Responses;

namespace Application.Features.Lessons.Commands.Create;

public class CreatedLessonResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ProducerCompanyId { get; set; }
    public Guid CourseId { get; set; }
    public Guid LanguageId { get; set; }
    public string Name { get; set; }
    public double? Time { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
}