using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class StudentClassRoom : Entity<Guid>
{
    public int StudentId { get; set; }
    public int ClassRoomId { get; set; }
    public Student Student { get; set; }
    public ClassRoom ClassRoom { get; set; }
}
