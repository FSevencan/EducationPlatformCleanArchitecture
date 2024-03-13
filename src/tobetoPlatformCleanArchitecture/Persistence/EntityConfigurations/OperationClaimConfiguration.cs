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

        
        #region Categories
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Delete" });
        #endregion
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
        #region Certificates
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Delete" });
        #endregion
        #region ClassRooms
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassRooms.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassRooms.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassRooms.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassRooms.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassRooms.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassRooms.Delete" });
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
        #region Skills
        seeds.Add(new OperationClaim { Id = ++id, Name = "Skills.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Skills.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Skills.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Skills.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Skills.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Skills.Delete" });
        #endregion
        #region Students
        seeds.Add(new OperationClaim { Id = ++id, Name = "Students.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Students.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Students.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Students.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Students.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Students.Delete" });
        #endregion
        #region StudentClassRooms
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentClassRooms.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentClassRooms.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentClassRooms.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentClassRooms.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentClassRooms.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentClassRooms.Delete" });
        #endregion
        #region StudentSections
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentSections.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentSections.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentSections.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentSections.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentSections.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentSections.Delete" });
        #endregion
        #region StudentSkills
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentSkills.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentSkills.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentSkills.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentSkills.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentSkills.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentSkills.Delete" });
        #endregion
        
        #region Surveys
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Delete" });
        #endregion
        #region ClassRoomTypes
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassRoomTypes.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassRoomTypes.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassRoomTypes.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassRoomTypes.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassRoomTypes.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassRoomTypes.Delete" });
        #endregion
        #region ClassRoomTypeSections
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassRoomTypeSections.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassRoomTypeSections.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassRoomTypeSections.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassRoomTypeSections.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassRoomTypeSections.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassRoomTypeSections.Delete" });
        #endregion
        #region MentorshipSessions
        seeds.Add(new OperationClaim { Id = ++id, Name = "MentorshipSessions.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "MentorshipSessions.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "MentorshipSessions.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "MentorshipSessions.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "MentorshipSessions.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "MentorshipSessions.Delete" });
        #endregion
        #region CampusEncounters
        seeds.Add(new OperationClaim { Id = ++id, Name = "CampusEncounters.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CampusEncounters.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CampusEncounters.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CampusEncounters.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CampusEncounters.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CampusEncounters.Delete" });
        #endregion
        #region StudentLessons
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentLessons.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentLessons.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentLessons.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentLessons.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentLessons.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentLessons.Delete" });
        #endregion
        #region Choices
        seeds.Add(new OperationClaim { Id = ++id, Name = "Choices.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Choices.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Choices.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Choices.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Choices.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Choices.Delete" });
        #endregion
        #region Questions
        seeds.Add(new OperationClaim { Id = ++id, Name = "Questions.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Questions.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Questions.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Questions.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Questions.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Questions.Delete" });
        #endregion
        #region UserAnswers
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserAnswers.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserAnswers.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserAnswers.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserAnswers.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserAnswers.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserAnswers.Delete" });
        #endregion
        #region Districts
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Delete" });
        #endregion
        #region Provinces
        seeds.Add(new OperationClaim { Id = ++id, Name = "Provinces.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Provinces.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Provinces.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Provinces.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Provinces.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Provinces.Delete" });
        #region Contacts
        seeds.Add(new OperationClaim { Id = ++id, Name = "Contacts.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Contacts.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Contacts.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Contacts.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Contacts.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Contacts.Delete" });
        return seeds;
        #endregion
        #endregion
    }
}
