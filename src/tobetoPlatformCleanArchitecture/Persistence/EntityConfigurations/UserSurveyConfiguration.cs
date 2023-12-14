using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserSurveyConfiguration : IEntityTypeConfiguration<UserSurvey>
{
    public void Configure(EntityTypeBuilder<UserSurvey> builder)
    {
        builder.ToTable("UserSurveys").HasKey(us => us.Id);

        builder.Property(us => us.Id).HasColumnName("Id").IsRequired();
        builder.Property(us => us.UserId).HasColumnName("UserId");
        builder.Property(us => us.SurveyId).HasColumnName("SurveyId");
        builder.Property(us => us.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(us => us.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(us => us.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(us => !us.DeletedDate.HasValue);
    }
}