using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Choice : Entity<Guid>
{
    public Guid QuestionId { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }

    public Question Question { get; set; }  
}

