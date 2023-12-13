using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class UserSurvey:Entity<Guid>
{
    public int UserId { get; set; }
    public Guid SurveyId { get; set; }
    public AppUser User { get; set; }
    public Survey Survey { get; set; }
}
