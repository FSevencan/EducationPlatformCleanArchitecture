using Core.Persistence.Repositories;

namespace Domain.Entities;
public class ModuleAbout : Entity<Guid>
{
    public Guid ProducerCompanyId { get; set; }
    public Guid ModuleId { get; set; }

    public string? Text { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string EstimatedDuration { get; set; }

    //public int TotalVideo { get; set; } // Count ile çekilecek.
    //public string? ProducerCompany { get; set; } // Tablodan çekilecek.

    public virtual Module Module { get; set; }
    public virtual  ProducerCompany ProducerCompany { get; set; }
}

