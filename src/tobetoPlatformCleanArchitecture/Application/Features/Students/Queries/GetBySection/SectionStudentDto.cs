using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Queries.GetBySection;
public class SectionStudentDto:IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string CourseCount { get; set; }
    public ICollection<SectionInstructorDto> Instructor {  get; set; }
    
    
}
