using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProducerCompanyConfiguration : IEntityTypeConfiguration<ProducerCompany>
{
    public void Configure(EntityTypeBuilder<ProducerCompany> builder)
    {
        builder.ToTable("ProducerCompanies").HasKey(pc => pc.Id);

        builder.Property(pc => pc.Id).HasColumnName("Id").IsRequired();
        builder.Property(pc => pc.Name).HasColumnName("Name");
        builder.Property(pc => pc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pc => pc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pc => pc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pc => !pc.DeletedDate.HasValue);
    }
}