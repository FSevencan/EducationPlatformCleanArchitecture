using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CampusEncounterConfiguration : IEntityTypeConfiguration<CampusEncounter>
{
    public void Configure(EntityTypeBuilder<CampusEncounter> builder)
    {
        builder.ToTable("CampusEncounters").HasKey(ce => ce.Id);

        builder.Property(ce => ce.Id).HasColumnName("Id").IsRequired();
        builder.Property(ce => ce.Title).HasColumnName("Title");
        builder.Property(ce => ce.StartDateTime).HasColumnName("StartDateTime");
        builder.Property(ce => ce.Location).HasColumnName("Location");
        builder.Property(ce => ce.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ce => ce.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ce => ce.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ce => !ce.DeletedDate.HasValue);
    }
}