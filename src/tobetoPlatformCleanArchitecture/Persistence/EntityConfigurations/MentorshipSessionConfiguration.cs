using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MentorshipSessionConfiguration : IEntityTypeConfiguration<MentorshipSession>
{
    public void Configure(EntityTypeBuilder<MentorshipSession> builder)
    {
        builder.ToTable("MentorshipSessions").HasKey(ms => ms.Id);

        builder.Property(ms => ms.Id).HasColumnName("Id").IsRequired();
        builder.Property(ms => ms.Title).HasColumnName("Title");
        builder.Property(ms => ms.Date).HasColumnName("Date");
        builder.Property(ms => ms.Schedule).HasColumnName("Schedule");
        builder.Property(ms => ms.MeetingId).HasColumnName("MeetingId");
        builder.Property(ms => ms.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ms => ms.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ms => ms.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ms => !ms.DeletedDate.HasValue);
    }
}