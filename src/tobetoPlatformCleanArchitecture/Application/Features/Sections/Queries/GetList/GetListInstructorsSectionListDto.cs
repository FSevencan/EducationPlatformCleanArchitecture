using Core.Application.Dtos;
using System;
namespace Application.Features.Sections.Queries.GetList
{
    public class GetListInstructorsSectionListDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
    }
}