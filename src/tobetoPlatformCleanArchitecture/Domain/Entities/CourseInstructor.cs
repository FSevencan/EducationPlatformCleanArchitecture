using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CourseInstructor : Entity<Guid>
{
    public Guid CourseId { get; set; }
    public Guid InstructorId { get; set; }
    public Course? Course { get; set; }
    public Instructor? Instructor { get; set; }
}
