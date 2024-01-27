using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ExamConfiguration : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> builder)
    {
        builder.ToTable("Exams").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
        builder.Property(e => e.ClassRoomTypeId).HasColumnName("ClassRoomTypeId");
        builder.Property(e => e.Name).HasColumnName("Name");
        builder.Property(e => e.Description).HasColumnName("Description");
        builder.Property(e => e.Duration).HasColumnName("Duration");
        builder.Property(e => e.QuestionCount).HasColumnName("QuestionCount");
        builder.Property(e => e.QuestionType).HasColumnName("QuestionType");
        builder.Property(e => e.StartDate).HasColumnName("StartDate");
        builder.Property(e => e.EndDate).HasColumnName("EndDate");
        builder.Property(e => e.ClassRoomType).HasColumnName("ClassRoomType");
        builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
    }
}