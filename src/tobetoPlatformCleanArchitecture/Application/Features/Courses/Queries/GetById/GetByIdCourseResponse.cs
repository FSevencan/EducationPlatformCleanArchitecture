using Application.Features.Lessons.Queries.GetList;
using Core.Application.Responses;

namespace Application.Features.Courses.Queries.GetById;

public class GetByIdCourseResponse : IResponse
{
    public Guid Id { get; set; }
    public double? TotalTime { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }    
}