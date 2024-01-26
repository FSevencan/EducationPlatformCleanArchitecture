using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Survey : Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

   
}
