using Application.Features.Lessons.Queries.GetList;
using Core.Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sections.Queries.GetById.Dtos;
public class GetCourseLessonListDto : IDto
{
    public Guid Id { get; set; }
    public double? TotalTime { get; set; }
    public string? Name { get; set; }
    public ICollection<GetListLessonListItemDto>? Lessons { get; set; }
}
