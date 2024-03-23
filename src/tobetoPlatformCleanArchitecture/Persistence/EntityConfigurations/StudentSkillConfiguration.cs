using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentSkillConfiguration : IEntityTypeConfiguration<StudentSkill>
{
    public void Configure(EntityTypeBuilder<StudentSkill> builder)
    {
        builder.ToTable("StudentSkills").HasKey(ss => ss.Id);

        builder.Property(ss => ss.Id).HasColumnName("Id").IsRequired();
        builder.Property(ss => ss.StudentId).HasColumnName("StudentId");
        builder.Property(ss => ss.SkillId).HasColumnName("SkillId");
        builder.Property(ss => ss.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ss => ss.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ss => ss.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ss => !ss.DeletedDate.HasValue);
    }
}