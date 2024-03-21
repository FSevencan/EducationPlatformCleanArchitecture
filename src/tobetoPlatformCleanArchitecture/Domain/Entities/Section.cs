using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Section : Entity<Guid>
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public int TotalLike { get; set; } = 0;

    public SectionAbout SectionAbout { get; set; }
    public Category? Category { get; set; }
    public ICollection<ClassRoomTypeSection>? ClassRoomTypeSection { get; set; }
    public ICollection<SectionCourse>? SectionCourses { get; set; }
    public ICollection<SectionInstructor>? SectionInstructors { get; set; }
    public ICollection<Like>? Likes { get; set; }

}
