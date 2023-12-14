using Core.Persistence.Repositories;

namespace Domain.Entities;
public class ModuleInstructor : Entity<Guid>
{
    public Guid ModuleId { get; set; }
    public Guid InstructorId { get; set; }

    public virtual Module Module { get; set; }
    public virtual Instructor Instructor { get; set; }
}
