using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Subscription : Entity<Guid>
{
    public int UserId { get; set; } 
    public Guid ClassRoomTypeId { get; set; } 

    public virtual User? User { get; set; }
    public virtual ClassRoomType? ClassRoomType { get; set; }

}