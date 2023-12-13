using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Course : Entity<Guid>
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public ICollection<ModuleCourse>? ModuleCourses { get; set; }

    public ICollection<ModuleInstructor>? CourseInstructor { get; set; }
}
