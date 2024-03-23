using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Certificate : Entity<Guid>
{
    public string? Name { get; set; }
    public string? Image { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
}
