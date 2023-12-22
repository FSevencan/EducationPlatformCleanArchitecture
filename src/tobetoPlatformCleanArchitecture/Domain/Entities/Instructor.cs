using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;
public class Instructor : Entity<Guid>
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? ImageUrl { get; set; }
    public string Email { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? PhoneNumber { get; set; }
    public string? About { get; set; }
    public string? Title { get; set; }

    public User? User { get; set; }

    public ICollection<SectionInstructor>? SectionInstructors { get; set; }
}
