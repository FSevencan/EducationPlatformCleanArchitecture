using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Queries.GetBySection;
public class SectionInstructorDto:IDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
}
