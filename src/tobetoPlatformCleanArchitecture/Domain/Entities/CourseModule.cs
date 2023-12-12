using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CourseModule : Entity<Guid>
{
    public Guid CourseId { get; set; }
    public Course Course { get; set; }
    public Guid ModuleId { get; set; }
    public Module Module { get; set; }
}
