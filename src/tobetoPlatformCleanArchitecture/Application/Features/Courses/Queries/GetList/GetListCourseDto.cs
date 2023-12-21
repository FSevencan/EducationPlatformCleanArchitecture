using Core.Application.Dtos;
using System;
namespace Application.Features.Courses.Queries.GetList
{
    public class GetListCourseDto : IDto
    {
        public Guid Id { get; set; }
        public double? TotalTime { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}