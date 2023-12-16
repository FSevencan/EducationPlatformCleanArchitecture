using Application.Features.OperationClaims.Constants;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasMany(oc => oc.UserOperationClaims);

        builder.HasData(getSeeds());
    }

    private HashSet<OperationClaim> getSeeds()
    {
        int id = 0;
        HashSet<OperationClaim> seeds =
            new()
            {
                new OperationClaim { Id = ++id, Name = GeneralOperationClaims.Admin }
            };

        
        #region Announcements
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Delete" });
        #endregion
        #region ApplicationEducations
        seeds.Add(new OperationClaim { Id = ++id, Name = "ApplicationEducations.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ApplicationEducations.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ApplicationEducations.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ApplicationEducations.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ApplicationEducations.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ApplicationEducations.Delete" });
        #endregion
        #region Categories
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Delete" });
        #endregion
        #region Courses       
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Delete" });
        #endregion
        #region Exams
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Delete" });
        #endregion
        #region Instructors
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Delete" });
        #endregion
        #region Languages
        seeds.Add(new OperationClaim { Id = ++id, Name = "Languages.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Languages.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Languages.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Languages.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Languages.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Languages.Delete" });
        #endregion
        #region Lessons
        seeds.Add(new OperationClaim { Id = ++id, Name = "Lessons.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Lessons.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Lessons.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Lessons.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Lessons.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Lessons.Delete" });
        #endregion
        #region ProducerCompanies
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProducerCompanies.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProducerCompanies.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProducerCompanies.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProducerCompanies.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProducerCompanies.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProducerCompanies.Delete" });
        #endregion
        #region Sections
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sections.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sections.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sections.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sections.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sections.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sections.Delete" });
        #endregion
        #region SectionAbouts
        seeds.Add(new OperationClaim { Id = ++id, Name = "SectionAbouts.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SectionAbouts.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SectionAbouts.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SectionAbouts.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SectionAbouts.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SectionAbouts.Delete" });
        #endregion
        #region SectionCourses
        seeds.Add(new OperationClaim { Id = ++id, Name = "SectionCourses.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SectionCourses.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SectionCourses.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SectionCourses.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SectionCourses.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SectionCourses.Delete" });
        #endregion
        #region SectionInstructors
        seeds.Add(new OperationClaim { Id = ++id, Name = "SectionInstructors.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SectionInstructors.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SectionInstructors.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SectionInstructors.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SectionInstructors.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SectionInstructors.Delete" });
        #endregion
        #region Surveys
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Delete" });
        #endregion
        #region UserSections
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserSections.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserSections.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserSections.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserSections.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserSections.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserSections.Delete" });
        #endregion
        #region UserSurveys
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserSurveys.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserSurveys.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserSurveys.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserSurveys.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserSurveys.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserSurveys.Delete" });
        #endregion
      
        #region AppUsers
        seeds.Add(new OperationClaim { Id = ++id, Name = "AppUsers.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AppUsers.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AppUsers.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AppUsers.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AppUsers.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AppUsers.Delete" });
        #endregion
        return seeds;
       
    }
}
