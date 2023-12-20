﻿using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Skill : Entity<Guid>
{
    public string Name { get; set; }
    public int Level { get; set; }
    public ICollection<StudentSkill> StudentSkills { get; set; }
}
