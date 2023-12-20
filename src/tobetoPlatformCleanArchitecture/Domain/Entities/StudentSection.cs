using Core.Persistence.Repositories;

namespace Domain.Entities;
public class StudentSection : Entity<Guid>
{
    public Guid SectionId { get; set; }
    public int StudentId { get; set; }

    public  Student Student { get; set; }
    public  Section Section { get; set; }   
}
