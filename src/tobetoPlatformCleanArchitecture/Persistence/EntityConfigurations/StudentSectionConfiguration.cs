using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentSectionConfiguration : IEntityTypeConfiguration<StudentClassRoom>
{
    public void Configure(EntityTypeBuilder<StudentClassRoom> builder)
    {
        builder.ToTable("StudentClassRoom").HasKey(ss => ss.Id);

        builder.Property(ss => ss.Id).HasColumnName("Id").IsRequired();
        builder.Property(ss => ss.ClassRoomId).HasColumnName("ClassRoomId");
        builder.Property(ss => ss.StudentId).HasColumnName("StudentId");
        builder.Property(ss => ss.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ss => ss.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ss => ss.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ss => !ss.DeletedDate.HasValue);
    }
}