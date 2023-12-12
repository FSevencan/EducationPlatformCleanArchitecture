using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class AssignmentContent : Content
{
    public string Description { get; set; }
    public string File { get; set; }
    public DateTime SendDate { get; set; }
}
