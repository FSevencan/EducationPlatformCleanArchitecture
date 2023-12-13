using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Module : Entity<Guid>
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public Guid ModuleAboutId { get; set; }
    public ModuleAbout ModuleAbout { get; set; }

    public ICollection<ModuleCourse> ModuleCourses { get; set; }

    public ICollection<ModuleInstructor>? ModuleInstructors { get; set; }

}
