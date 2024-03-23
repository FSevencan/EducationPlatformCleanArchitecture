using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contacts").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.FirstName).HasColumnName("FirstName");
        builder.Property(c => c.LastName).HasColumnName("LastName");
        builder.Property(c => c.Email).HasColumnName("Email");
        builder.Property(c => c.Subject).HasColumnName("Subject");
        builder.Property(c => c.Message).HasColumnName("Message");
        builder.Property(c => c.ReadDate).HasColumnName("ReadDate");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}