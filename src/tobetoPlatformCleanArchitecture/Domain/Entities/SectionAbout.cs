using Core.Persistence.Repositories;

namespace Domain.Entities;
public class SectionAbout : Entity<Guid>
{
    public Guid ProducerCompanyId { get; set; }
    public Guid SectionId { get; set; }
    public Guid LanguageId { get; set; }
    public string? Text { get; set; }
    public double EstimatedDuration { get; set; }

    public Section Section { get; set; }
    public ProducerCompany ProducerCompany { get; set; }
    public Language Language { get; set; }
}

