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
    public DbSet<AppUser> Users { get; set; }
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
    public DbSet<UserSection> UserSections { get; set; }
    public DbSet<UserSurvey> UserSurveys { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Section>()
            .HasOne(s => s.SectionAbout)
            .WithOne(sa => sa.Section)
            .HasForeignKey<SectionAbout>(sa => sa.SectionId);

        modelBuilder.Entity<SectionCourse>()
             .HasOne(sc => sc.Section)
             .WithMany(s => s.SectionCourses)
             .HasForeignKey(sc => sc.SectionId)
             .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
