using Core.Persistence.Repositories;

namespace Domain.Entities;
public class StudentClassRoom : Entity<Guid>
{
    public Guid ClassRoomId { get; set; }
    public int StudentId { get; set; }

    public  ClassRoom ClassRoom { get; set; }
    public  Student Student  { get; set; }   
}
