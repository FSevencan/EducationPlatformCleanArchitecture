using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ClassRoomConfiguration : IEntityTypeConfiguration<ClassRoom>
{
    public void Configure(EntityTypeBuilder<ClassRoom> builder)
    {
        builder.ToTable("ClassRooms").HasKey(cr => cr.Id);

        builder.Property(cr => cr.Id).HasColumnName("Id").IsRequired();
        builder.Property(cr => cr.Branch).HasColumnName("Branch");
        builder.Property(cr => cr.ClassRoomTypeId).HasColumnName("ClassRoomTypeId");
        builder.Property(cr => cr.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cr => cr.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cr => cr.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cr => !cr.DeletedDate.HasValue);
    }
}