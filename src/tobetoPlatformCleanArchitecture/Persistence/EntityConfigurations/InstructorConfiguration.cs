using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.ToTable("Instructors").HasKey(i => i.Id);

        builder.Property(i => i.Id).HasColumnName("Id").IsRequired();
        builder.Property(i => i.UserId).HasColumnName("UserId");
        builder.Property(i => i.FirstName).HasColumnName("FirstName");
        builder.Property(i => i.LastName).HasColumnName("LastName");
        builder.Property(i => i.ImageUrl).HasColumnName("ImageUrl");
        builder.Property(i => i.Email).HasColumnName("Email");
        builder.Property(i => i.BirthDate).HasColumnName("BirthDate");
        builder.Property(i => i.PhoneNumber).HasColumnName("PhoneNumber");
        builder.Property(i => i.About).HasColumnName("About");
        builder.Property(i => i.Title).HasColumnName("Title");
        builder.Property(i => i.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(i => i.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(i => i.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}