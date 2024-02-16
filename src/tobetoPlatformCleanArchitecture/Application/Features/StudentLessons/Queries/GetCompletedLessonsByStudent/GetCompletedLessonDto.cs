using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StudentLessons.Queries.GetCompletedLessonsByStudent;
public class GetCompletedLessonDto : IDto
{
    public Guid LessonId { get; set; }
    public bool IsCompleted { get; set; }
}