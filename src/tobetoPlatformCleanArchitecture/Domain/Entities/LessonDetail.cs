using Core.Persistence.Repositories;

namespace Domain.Entities;
public class LessonDetail : Entity<Guid>
{
    public Guid LanguageId { get; set; }
    public Guid LessonId { get; set; }

    public string ProducerCompany { get; set; }
    public string Description { get; set; }

    public virtual Language Language { get; set; }
    public virtual Lesson Lesson { get; set; }

}
