using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<ApplicationEducation> ApplicationEducations { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<SectionAbout> SectionAbouts { get; set; }
    public DbSet<SectionCourse> SectionCourses { get; set; }
    public DbSet<SectionInstructor> SectionInstructors { get; set; }
    public DbSet<ProducerCompany> ProducerCompanies { get; set; }
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<StudentClassRoom> StudentClassRooms { get; set; }

    public DbSet<Student> Students { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<StudentSkill> StudentSkills { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<ClassRoom> ClassRooms { get; set; }
    public DbSet<ClassRoomTypeSection> ClassRoomTypeSections { get; set; }
    public DbSet<ClassRoomType> ClassRoomTypes { get; set; }
    public DbSet<MentorshipSession> MentorshipSessions { get; set; }
    public DbSet<CampusEncounter> CampusEncounters { get; set; }
    public DbSet<StudentLesson> StudentLessons { get; set; }
    public DbSet<Choice> Choices { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<UserAnswer> UserAnswers { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
