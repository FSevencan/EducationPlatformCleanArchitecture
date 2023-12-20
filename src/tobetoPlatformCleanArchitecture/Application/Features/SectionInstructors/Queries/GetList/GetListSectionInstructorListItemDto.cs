using Core.Application.Dtos;
using Domain.Entities;

namespace Application.Features.SectionInstructors.Queries.GetList;

public class GetListSectionInstructorListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid SectionId { get; set; }
    public Guid InstructorId { get; set; }
    public Section Section { get; set; }
    public Instructor Instructor { get; set; }
}