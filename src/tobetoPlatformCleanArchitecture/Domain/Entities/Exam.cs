using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Exam : Entity<Guid>
{
    public Guid ClassRoomTypeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public int QuestionCount { get; set; }
    public string QuestionType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ClassRoomType ClassRoomType { get; set; }
}
