using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SectionAboutConfiguration : IEntityTypeConfiguration<SectionAbout>
{
    public void Configure(EntityTypeBuilder<SectionAbout> builder)
    {
        builder.ToTable("SectionAbouts").HasKey(sa => sa.Id);

        builder.Property(sa => sa.Id).HasColumnName("Id").IsRequired();
        builder.Property(sa => sa.ProducerCompanyId).HasColumnName("ProducerCompanyId");
        builder.Property(sa => sa.SectionId).HasColumnName("SectionId");
        builder.Property(sa => sa.Text).HasColumnName("Text");
        builder.Property(sa => sa.StartDate).HasColumnName("StartDate");
        builder.Property(sa => sa.EndDate).HasColumnName("EndDate");
        builder.Property(sa => sa.EstimatedDuration).HasColumnName("EstimatedDuration");
        builder.Property(sa => sa.Section).HasColumnName("Section");
        builder.Property(sa => sa.ProducerCompany).HasColumnName("ProducerCompany");
        builder.Property(sa => sa.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sa => sa.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sa => sa.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(sa => !sa.DeletedDate.HasValue);
    }
}