using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ApplicationEducationConfiguration : IEntityTypeConfiguration<ApplicationEducation>
{
    public void Configure(EntityTypeBuilder<ApplicationEducation> builder)
    {
        builder.ToTable("ApplicationEducations").HasKey(ae => ae.Id);

        builder.Property(ae => ae.Id).HasColumnName("Id").IsRequired();
        builder.Property(ae => ae.Name).HasColumnName("Name");
        builder.Property(ae => ae.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ae => ae.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ae => ae.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ae => !ae.DeletedDate.HasValue);
    }
}