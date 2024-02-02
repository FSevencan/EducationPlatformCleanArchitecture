using Application.Features.Courses.Queries.GetById;
using Application.Features.Courses.Queries.GetList;
using Application.Features.Instructors.Queries.GetList;
using Application.Features.Lessons.Queries.GetList;
using Application.Features.SectionAbouts.Queries.GetList;
using Application.Features.Sections.Queries.GetById.Dtos;
using Core.Application.Dtos;
using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Sections.Queries.GetById;

public class GetByIdSectionResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public string ProducerCompanyName { get; set; }
    public string LanguageName { get; set; }
    public DateTime CreatedDate { get; set; }

    public GetListSectionAboutListItemDto SectionAbout { get; set; }
    public ICollection<GetListInstructorDto> Instructors { get; set; }
    public ICollection<GetCourseLessonListDto> Courses { get; set; }

}
