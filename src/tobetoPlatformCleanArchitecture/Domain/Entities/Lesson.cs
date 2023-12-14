using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Lesson : Entity<Guid>
{
    public Guid ProducerCompanyId { get; set; }
    public Guid CourseId { get; set; }
    public Guid LanguageId { get; set; }

    public string Name { get; set; }
    public TimeSpan? Time { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }

    public  Course Course { get; set; }
    public  Language Language { get; set; }
    public  ProducerCompany ProducerCompany { get; set; }
}
