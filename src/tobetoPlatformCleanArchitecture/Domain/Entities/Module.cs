using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Module : Entity<Guid>
{
    public Guid CategoryId { get; set; }
    public Guid ModuleAboutId { get; set; }

    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }

    public virtual Category Category { get; set; }
    public virtual ModuleAbout ModuleAbout { get; set; }
    public virtual ICollection<ModuleCourse> ModuleCourses { get; set; }
    public virtual ICollection<ModuleInstructor> ModuleInstructors { get; set; }//?Nullable kaldırıldı.
    //live class sonrasında tartışılacak    
}

