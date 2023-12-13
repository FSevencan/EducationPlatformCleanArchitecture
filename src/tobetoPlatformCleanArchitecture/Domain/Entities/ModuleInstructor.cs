using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ModuleInstructor : Entity<Guid>
{
    public Guid ModuleId { get; set; }
    public Guid InstructorId { get; set; }
    public Module? Module { get; set; }
    public Instructor? Instructor { get; set; }
}
