using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Announcement : Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    
}
