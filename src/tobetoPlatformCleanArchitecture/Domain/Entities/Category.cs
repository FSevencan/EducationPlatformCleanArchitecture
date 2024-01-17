using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Category : Entity<Guid>
    {
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public  ICollection<Section> Sections { get; set; }       
    }
}
