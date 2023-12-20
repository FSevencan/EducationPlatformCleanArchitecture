using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentClassRoomConfiguration : IEntityTypeConfiguration<StudentClassRoom>
{
    public void Configure(EntityTypeBuilder<StudentClassRoom> builder)
    {
        builder.ToTable("StudentClassRooms").HasKey(scr => scr.Id);

        builder.Property(scr => scr.Id).HasColumnName("Id").IsRequired();
        builder.Property(scr => scr.StudentId).HasColumnName("StudentId");
        builder.Property(scr => scr.ClassRoomId).HasColumnName("ClassRoomId");
        builder.Property(scr => scr.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(scr => scr.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(scr => scr.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(scr => !scr.DeletedDate.HasValue);
    }
}