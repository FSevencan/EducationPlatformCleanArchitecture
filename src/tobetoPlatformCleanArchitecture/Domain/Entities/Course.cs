using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Course : Entity<Guid>
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    //public string ImageUrl { get; set; } //Kursun değil, Lesson'ın bir fotoğrafı olur.
    public string Description { get; set; }

    public virtual Category Category { get; set; }
    public virtual ICollection<ModuleCourse>? ModuleCourses { get; set; }
    public virtual ICollection<ModuleInstructor>? CourseInstructor { get; set; }
}
