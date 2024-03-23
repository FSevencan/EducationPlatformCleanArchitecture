using Core.Persistence.Repositories;
using Core.Security.Entities;
using Core.Security.Enums;

namespace Domain.Entities;
public class Student : Entity<int>
{
    public int UserId { get; set; }
    public int? ProvinceId { get; set; }
    public int? DistrictId { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Biography { get; set; }
    public string? GithubUrl { get; set; }
    public string? LinkedinUrl { get; set; }
    public User User { get; set; }
    public Province? Province { get; set; }
    public District? District { get; set; }
    public ICollection<StudentSkill> StudentSkills { get; set; }
    public ICollection<StudentClassRoom> StudentClassRooms { get; set; }
    public ICollection<Certificate> Certificates { get; set; }
    public ICollection<Like>? Likes { get; set; }


}