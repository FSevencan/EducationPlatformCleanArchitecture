using Core.Persistence.Repositories;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ContentDetail : Entity<Guid>
{
    public string ProducerCompany { get; set; }
    public string Description { get; set; }
    public Language Language { get; set; } // Enum olarak tanımlandı.

    public Guid ContentCategoryId { get; set; }
    public ContentCategory ContentCategory { get; set; }

    public VideoContent Video { get; set; }
    public Guid VideoId { get; set; }
}
