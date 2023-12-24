using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ClassRoomTypeConfiguration : IEntityTypeConfiguration<ClassRoomType>
{
    public void Configure(EntityTypeBuilder<ClassRoomType> builder)
    {
        builder.ToTable("ClassRoomTypes").HasKey(crt => crt.Id);

        builder.Property(crt => crt.Id).HasColumnName("Id").IsRequired();
        builder.Property(crt => crt.Name).HasColumnName("Name");
        builder.Property(crt => crt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(crt => crt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(crt => crt.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(crt => !crt.DeletedDate.HasValue);
    }
}