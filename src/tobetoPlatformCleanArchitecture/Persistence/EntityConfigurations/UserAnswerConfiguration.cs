using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserAnswerConfiguration : IEntityTypeConfiguration<UserAnswer>
{
    public void Configure(EntityTypeBuilder<UserAnswer> builder)
    {
        builder.ToTable("UserAnswers").HasKey(ua => ua.Id);

        builder.Property(ua => ua.Id).HasColumnName("Id").IsRequired();
        builder.Property(ua => ua.UserId).HasColumnName("UserId");    
        builder.Property(ua => ua.CorrectCount).HasColumnName("CorrectCount");
        builder.Property(ua => ua.WrongCount).HasColumnName("WrongCount");
        builder.Property(ua => ua.EmptyCount).HasColumnName("EmptyCount");
        builder.Property(ua => ua.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ua => ua.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ua => ua.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ua => !ua.DeletedDate.HasValue);

    }
}