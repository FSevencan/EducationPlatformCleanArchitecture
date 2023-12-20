using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SectionCourseConfiguration : IEntityTypeConfiguration<SectionCourse>
{
    public void Configure(EntityTypeBuilder<SectionCourse> builder)
    {
        builder.ToTable("SectionCourses").HasKey(sc => sc.Id);

        builder.Property(sc => sc.Id).HasColumnName("Id").IsRequired();
        builder.Property(sc => sc.CourseId).HasColumnName("CourseId");
        builder.Property(sc => sc.SectionId).HasColumnName("SectionId");
        builder.Property(sc => sc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sc => sc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sc => sc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(sc => !sc.DeletedDate.HasValue);
    }
}