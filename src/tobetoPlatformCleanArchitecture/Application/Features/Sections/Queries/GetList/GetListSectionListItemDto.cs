using Application.Features.Categories.Queries.GetList;
using Application.Features.Courses.Queries.GetList;
using Application.Features.Instructors.Queries.GetList;
using Application.Features.Lessons.Queries.GetList;
using Application.Features.SectionAbouts.Queries.GetList;
using Application.Features.Sections.Queries.GetById.Dtos;
using Core.Application.Dtos;

namespace Application.Features.Sections.Queries.GetList;

public class GetListSectionListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; } // eklenen
    public string CategoryName { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public string ProducerCompany { get; set; }

    public GetListSectionAboutListItemDto SectionAbout { get; set; }
    public ICollection<GetListCourseDto> Courses { get; set; }
    public ICollection<GetListInstructorDto> Instructors { get; set; }

}
