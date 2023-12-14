using Core.Persistence.Repositories;

namespace Domain.Entities;
public class ProducerCompany:Entity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; }
    public virtual ICollection<ModuleAbout> ModuleAbouts { get; set; }
}
