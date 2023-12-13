using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class LessonDetail : Entity<Guid>
{
    public string ProducerCompany { get; set; }
    public string Description { get; set; }

    public Guid LanguageId { get; set; }
    public Language Language { get; set; }

    public Guid LessonId { get; set; }
    public Lesson Lesson { get; set; }

}
