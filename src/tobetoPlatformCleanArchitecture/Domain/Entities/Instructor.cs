using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Instructor : Entity<Guid>
{
    public string Name { get; set; }
    public string? ImageUrl { get; set; }

    public  ICollection<SectionInstructor>? SectionInstructors { get; set; }
}
