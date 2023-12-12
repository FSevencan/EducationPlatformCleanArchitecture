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
    public string Title { get; set; }

    public ICollection<Content> Contents { get; set; }
    public ICollection<CourseModule> CourseModules { get; set; } // Bir Modülü başka kurslarda da kullanmak için
}
