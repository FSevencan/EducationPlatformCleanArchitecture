using Core.Persistence.Repositories;

namespace Domain.Entities;
public class ApplicationEducation:Entity<Guid>
{   
    public string Name { get; set; }
}
