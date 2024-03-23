using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ClassRoomTypeSectionConfiguration : IEntityTypeConfiguration<ClassRoomTypeSection>
{
    public void Configure(EntityTypeBuilder<ClassRoomTypeSection> builder)
    {
        builder.ToTable("ClassRoomTypeSections").HasKey(crts => crts.Id);

        builder.Property(crts => crts.Id).HasColumnName("Id").IsRequired();
        builder.Property(crts => crts.ClassRoomTypeId).HasColumnName("ClassRoomTypeId");
        builder.Property(crts => crts.SectionId).HasColumnName("SectionId");
        builder.Property(crts => crts.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(crts => crts.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(crts => crts.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(crts => !crts.DeletedDate.HasValue);
    }
}