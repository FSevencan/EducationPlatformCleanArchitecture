using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public class UserAnswer : Entity<Guid>
{
    public int UserId { get; set; }
    public Guid ExamId { get; set; } 
    public int CorrectCount { get; set; }
    public int WrongCount { get; set; }
    public int EmptyCount { get; set; }
    public int? TotalScore { get; set; } 

    public User User { get; set; }
    public Exam Exam { get; set; }    
}





