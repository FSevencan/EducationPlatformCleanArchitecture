using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sections.Queries.GetSearchSections;
public class GetSearchInstructorDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? ImageUrl { get; set; }

}
