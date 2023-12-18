using Core.Application.Dtos;
using System;
namespace Application.Features.Instructors.Queries.GetList
{
    public class GetListInstructorDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
    }
}

