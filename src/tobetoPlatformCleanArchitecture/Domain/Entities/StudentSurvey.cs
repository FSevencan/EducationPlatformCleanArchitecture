using Core.Persistence.Repositories;

namespace Domain.Entities;
public class StudentSurvey : Entity<Guid>
{
    public int StudentId { get; set; }
    public Guid SurveyId { get; set; }

    public  Student Student { get; set; }
    public  Survey Survey { get; set; }
}
