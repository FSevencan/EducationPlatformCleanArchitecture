using Application.Features.Instructors.Queries.GetList;
using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sections.Queries.GetSearchSections;
public class GetSearchSectionListDto : IDto
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string CourseCount { get; set; }

    public ICollection<GetSearchInstructorDto> Instructors { get; set; }
}
