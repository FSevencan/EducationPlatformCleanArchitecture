using Core.Application.Responses;

namespace Application.Features.SectionCourses.Queries.GetById;

public class GetByIdSectionCourseResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid SectionId { get; set; }


}