using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Section : Entity<Guid>
{
    public Guid CategoryId { get; set; }

    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }

    public SectionAbout SectionAbout { get; set; }


    public Category? Category { get; set; }
    public ICollection<UserSection>? UserSections { get; set; } //sonradan eklendi
    public ICollection<SectionCourse>? SectionCourses { get; set; }
    public ICollection<SectionInstructor>? SectionInstructors { get; set; }
}
