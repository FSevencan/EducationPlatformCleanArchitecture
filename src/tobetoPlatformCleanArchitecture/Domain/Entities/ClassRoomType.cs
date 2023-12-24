using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ClassRoomType: Entity<Guid>
{
    public string Name { get; set; } // Örnek: ".NET Full Stack"
    public ICollection<ClassRoomTypeSection> ClassRoomTypeSection { get; set; } 
}
