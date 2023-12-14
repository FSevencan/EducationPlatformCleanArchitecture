using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Instructor : Entity<Guid>
{
    public string Name { get; set; }
    public string? ImageUrl { get; set; }

    public virtual ICollection<ModuleInstructor>? ModuleInstructors { get; set; }
}
