using Core.Persistence.Repositories;
using Core.Security.Entities;
using Core.Security.Enums;

namespace Domain.Entities;
public class AppUser : User
{
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string About { get; set; }
    public string? GithubUrl { get; set; }
    public string? LinkedinUrl { get; set; }


    public ICollection<UserSection> UserSections { get; set; }
    public ICollection<UserSurvey> UserSurveys { get; set; }

   
   

}

