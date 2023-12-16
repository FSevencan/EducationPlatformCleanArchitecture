using Core.Persistence.Repositories;

namespace Domain.Entities;
public class SectionAbout : Entity<Guid>
{
    public Guid ProducerCompanyId { get; set; }
    public Guid SectionId { get; set; }

    public string? Text { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime EstimatedDuration { get; set; }  

    public  Section Section { get; set; }
    public  ProducerCompany ProducerCompany { get; set; }
}

