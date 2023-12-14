using Core.Persistence.Repositories;

namespace Domain.Entities;
public class UserModule : Entity<Guid>
{
    public Guid ModuleId { get; set; }
    public int UserId { get; set; }

    public virtual AppUser User { get; set; }
    public virtual Module Module { get; set; }
    //tamamlandı tamamlanmadı mı ? koyulsun mu?    
}
