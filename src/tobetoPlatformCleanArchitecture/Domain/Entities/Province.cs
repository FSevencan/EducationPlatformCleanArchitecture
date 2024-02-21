using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Province: Entity<int>
{
    public string Name { get; set; }

    public ICollection<District> Districts { get; set; }

}