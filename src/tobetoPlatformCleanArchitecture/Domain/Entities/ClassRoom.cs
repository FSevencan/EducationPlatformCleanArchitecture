using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ClassRoom : Entity<Guid>
{
    public string Branch { get; set; } // Örnek: "1-A"
    public Guid ClassRoomTypeId { get; set; } 

    public virtual ClassRoomType ClassRoomType { get; set; } 
    public string Name => $"{ClassRoomType.Name} {Branch}"; // Birleşik İsim Oluşturma

    public ICollection<StudentClassRoom> StudentClassRooms { get; set; }
}
