using Core.Persistence.Repositories;
using Core.Security.Entities;
using Core.Security.Enums;

namespace Domain.Entities;
public class Student : Entity<int>
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImageUrl { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string About { get; set; }
    public string? GithubUrl { get; set; }
    public string? LinkedinUrl { get; set; }

    public User User { get; set; }
    public ICollection<StudentSection> StudentSections { get; set; }
    public ICollection<StudentSurvey> StudentSurveys { get; set; }
    public ICollection<StudentSkill> StudentSkills { get; set; }
    public ICollection<StudentClassRoom> StudentClassRooms { get; set; }
    public ICollection<Certificate> Certificates { get; set; }
   

}

