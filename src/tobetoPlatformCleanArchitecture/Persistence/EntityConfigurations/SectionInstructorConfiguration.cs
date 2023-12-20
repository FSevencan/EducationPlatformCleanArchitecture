using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SectionInstructorConfiguration : IEntityTypeConfiguration<SectionInstructor>
{
    public void Configure(EntityTypeBuilder<SectionInstructor> builder)
    {
        builder.ToTable("SectionInstructors").HasKey(si => si.Id);

        builder.Property(si => si.Id).HasColumnName("Id").IsRequired();
        builder.Property(si => si.SectionId).HasColumnName("SectionId");
        builder.Property(si => si.InstructorId).HasColumnName("InstructorId");
        builder.Property(si => si.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(si => si.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(si => si.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(si => !si.DeletedDate.HasValue);
    }
}