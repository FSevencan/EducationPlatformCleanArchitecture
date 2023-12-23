using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.UserId).HasColumnName("UserId");
        //builder.Property(s => s.FirstName).HasColumnName("FirstName");
        //builder.Property(s => s.LastName).HasColumnName("LastName");
        builder.Property(s => s.ImageUrl).HasColumnName("ImageUrl");
        //builder.Property(s => s.Email).HasColumnName("Email");
        builder.Property(s => s.BirthDate).HasColumnName("BirthDate");
        builder.Property(s => s.PhoneNumber).HasColumnName("PhoneNumber");
        builder.Property(s => s.About).HasColumnName("About");
        builder.Property(s => s.GithubUrl).HasColumnName("GithubUrl");
        builder.Property(s => s.LinkedinUrl).HasColumnName("LinkedinUrl");
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
    }
}