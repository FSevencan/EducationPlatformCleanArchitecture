using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class StudentSkill : Entity<Guid>
{
    public int StudentId { get; set; }
    public Guid SkillId { get; set; }
    public Student Student { get; set; }
    public Skill Skill { get; set; }
}
