using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CampusEncounter : Entity<Guid>
{
    public string Title { get; set; } 
    public DateTime StartDateTime { get; set; } 
    public string Location { get; set; }
   
}
