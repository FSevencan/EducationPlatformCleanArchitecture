using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class MentorshipSession : Entity<Guid>
{
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Schedule { get; set; }
    public string MeetingId { get; set; }
}
