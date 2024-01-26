using Application.Features.Courses.Queries.GetById;
using Application.Features.Courses.Queries.GetList;
using Application.Features.SectionAbouts.Queries.GetList;
using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Sections.Queries.GetById;

public class GetByIdSectionResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }

    public GetListSectionAboutListItemDto? SectionAbout { get; set; }
    public ICollection<GetListCourseDto> Courses { get; set; }
    public ICollection<GetListCourseDto> Lessons { get; set; }
}