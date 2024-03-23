using Core.Persistence.Repositories;

namespace Domain.Entities;
public class SectionInstructor : Entity<Guid>
{
    public Guid SectionId { get; set; }
    public int InstructorId { get; set; }

    public  Section Section { get; set; }
    public  Instructor Instructor { get; set; }
}
