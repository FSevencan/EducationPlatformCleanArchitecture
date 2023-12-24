using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Lesson : Entity<Guid>
{
    public Guid CourseId { get; set; }
    public Guid LanguageId { get; set; }

    public string Name { get; set; }
    public double Time { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }

    public Course Course { get; set; }
    public Language Language { get; set; }
   
}
