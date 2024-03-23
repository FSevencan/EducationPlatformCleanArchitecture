using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ClassRoomTypeSection : Entity<Guid>
{
    public Guid ClassRoomTypeId { get; set; }
    public Guid SectionId { get; set; }
    public Section Section { get; set; }
    public ClassRoomType ClassRoomType { get; set; }
}
