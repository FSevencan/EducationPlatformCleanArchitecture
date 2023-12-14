using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Lesson : Entity<Guid>
{
    public Guid LessonDetailId { get; set; }
    public Guid ProducerCompanyId { get; set; }
    public Guid CourseId { get; set; }
    public Guid LanguageId { get; set; }
    //public Guid LessonCategoryId { get; set; }

    public string Name { get; set; }
    public string Time { get; set; }
    public string? ImageUrl { get; set; }

    public virtual LessonDetail LessonDetail { get; set; }   
    public virtual Course Course { get; set; }
    public virtual Language Language { get; set; }
    public virtual ProducerCompany ProducerCompany { get; set; }
    //Kullanacağımız template'e göre Lesson'ların kategorileri yok. Modüllerin var.
    //public virtual LessonCategory LessonCategory { get; set; }
}
