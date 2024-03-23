using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class District: Entity<int>
{
    public int ProvinceId { get; set; }
    public string Name { get; set; }
    public Province Province { get; set; }
}
