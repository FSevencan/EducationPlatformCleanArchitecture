using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class UserModule:Entity<Guid>
{
    public int UserId { get; set; }
    public Guid ModuleId { get; set; }
    public AppUser User { get; set; }
    public Module Module { get; set; }
    //tamamlandı tamamlanmadı mı ? koyulsun mu?
    
}
