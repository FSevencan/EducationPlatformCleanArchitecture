using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentClassRoomConfiguration : IEntityTypeConfiguration<ClassRoomTypeSection>
{
    public void Configure(EntityTypeBuilder<ClassRoomTypeSection> builder)
    {
        builder.ToTable("ClassRoomTypeSection").HasKey(scr => scr.Id);

        builder.Property(scr => scr.Id).HasColumnName("Id").IsRequired();
        builder.Property(scr => scr.SectionId).HasColumnName("SectionId");
        builder.Property(scr => scr.ClassRoomTypeId).HasColumnName("ClassRoomTypeId");
        builder.Property(scr => scr.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(scr => scr.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(scr => scr.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(scr => !scr.DeletedDate.HasValue);
    }
}