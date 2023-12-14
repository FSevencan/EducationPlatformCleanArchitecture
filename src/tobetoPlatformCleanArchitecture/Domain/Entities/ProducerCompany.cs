using Core.Persistence.Repositories;

namespace Domain.Entities;
public class ProducerCompany:Entity<Guid>
{
    public string Name { get; set; }

    public  ICollection<Lesson> Lessons { get; set; }
    public  ICollection<SectionAbout> SectionAbouts { get; set; }
}
