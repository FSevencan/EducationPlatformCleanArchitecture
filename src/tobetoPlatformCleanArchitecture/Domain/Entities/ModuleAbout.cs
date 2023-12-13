using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ModuleAbout : Entity<Guid>
{
    public string? Text { get; set; } 
    public DateTime StartDate { get; set; } 
    public DateTime EndDate { get; set; } 
    public string EstimatedDuration { get; set; } 
    public int TotalVideo { get; set; } 
    public string? ProducerCompany { get; set; }

    public Guid ModuleId { get; set; }
    public Module Module { get; set; }
    
}

