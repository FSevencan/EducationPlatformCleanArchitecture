using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.ToTable("Subscriptions").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.UserId).HasColumnName("UserId");
        builder.Property(s => s.ClassRoomTypeId).HasColumnName("ClassRoomTypeId");
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
    }
}