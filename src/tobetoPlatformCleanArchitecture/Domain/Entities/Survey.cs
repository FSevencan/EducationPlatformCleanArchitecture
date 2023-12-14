using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Survey : Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime FinishDate { get; set; }

    public virtual ICollection<UserSurvey> UserSurveys { get; set; }
}
