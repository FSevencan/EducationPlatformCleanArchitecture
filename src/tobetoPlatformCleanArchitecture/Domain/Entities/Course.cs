using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Course : Entity<Guid>
{
    public double TotalTime { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Lesson>? Lessons { get; set; }
    public ICollection<SectionCourse>? SectionCourses { get; set; }
}

