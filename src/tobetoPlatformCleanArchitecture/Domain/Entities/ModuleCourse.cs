using Core.Persistence.Repositories;

namespace Domain.Entities;
public class ModuleCourse : Entity<Guid>
{
    public Guid CourseId { get; set; }
    public Guid ModuleId { get; set; }
    
    public virtual Module Module { get; set; }
    public virtual Course Course { get; set; }   
}
