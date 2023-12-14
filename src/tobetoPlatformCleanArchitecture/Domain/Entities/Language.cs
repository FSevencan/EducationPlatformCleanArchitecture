using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Language : Entity<Guid>
{
    public string Name { get; set; }

}
