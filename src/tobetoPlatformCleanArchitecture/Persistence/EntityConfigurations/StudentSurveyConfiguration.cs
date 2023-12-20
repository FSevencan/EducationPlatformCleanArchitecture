using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentSurveyConfiguration : IEntityTypeConfiguration<StudentSurvey>
{
    public void Configure(EntityTypeBuilder<StudentSurvey> builder)
    {
        builder.ToTable("StudentSurveys").HasKey(ss => ss.Id);

        builder.Property(ss => ss.Id).HasColumnName("Id").IsRequired();
        builder.Property(ss => ss.StudentId).HasColumnName("StudentId");
        builder.Property(ss => ss.SurveyId).HasColumnName("SurveyId");
        builder.Property(ss => ss.Student).HasColumnName("Student");
        builder.Property(ss => ss.Survey).HasColumnName("Survey");
        builder.Property(ss => ss.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ss => ss.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ss => ss.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ss => !ss.DeletedDate.HasValue);
    }
}