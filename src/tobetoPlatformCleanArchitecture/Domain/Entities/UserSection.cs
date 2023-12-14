using Core.Persistence.Repositories;

namespace Domain.Entities;
public class UserSection : Entity<Guid>
{
    public Guid SectionId { get; set; }
    public int UserId { get; set; }

    public  AppUser User { get; set; }
    public  Section Section { get; set; }   
}
