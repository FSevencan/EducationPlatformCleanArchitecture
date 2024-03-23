using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;
public class Instructor : Entity<int>
{
    public int UserId { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Biography { get; set; }
    public string? Title { get; set; }
    public string? GithubUrl { get; set; }
    public string? LinkedinUrl { get; set; }
    public string? TwitterUrl { get; set; }

    public User? User { get; set; }

    public ICollection<SectionInstructor>? SectionInstructors { get; set; }
}
