using Core.Persistence.Repositories;

namespace Domain.Entities;
public class SectionCourse : Entity<Guid>
{
    public Guid CourseId { get; set; }
    public Guid SectionId { get; set; }
    
    public  Section Section { get; set; }
    public  Course Course { get; set; }   
}
