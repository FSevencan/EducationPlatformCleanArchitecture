using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Content : Entity<Guid>
{
    public string Title { get; set; }
    public string Time { get; set; }
    public string? ImageUrl { get; set; }

    public Guid ContentDetailId { get; set; }
    public ContentDetail ContentDetail { get; set; }


    public Guid ModuleId { get; set; }
    public Module Module { get; set; }
}
