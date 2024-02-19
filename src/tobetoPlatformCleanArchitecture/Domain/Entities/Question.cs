using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Question : Entity<Guid>
{
    public string Text { get; set; }
    public Guid ExamId { get; set; }

    public ICollection<Choice> Choices { get; set; }
    public Exam Exam { get; set; }
}


