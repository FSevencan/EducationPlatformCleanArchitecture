using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Lesson : Entity<Guid>
{
    public Guid LessonDetailId { get; set; }
    public Guid LessonCategoryId { get; set; }
    public Guid CourseId { get; set; }
    public Guid LanguageId { get; set; }

    public string Name { get; set; }
    public string Time { get; set; }
    public string? ImageUrl { get; set; }

   
    public LessonDetail LessonDetail { get; set; }
    public LessonCategory LessonCategory { get; set; }
    public Course Course { get; set; }
    public Language Language { get; set; }

}
