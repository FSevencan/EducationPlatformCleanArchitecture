using Core.Application.Dtos;

namespace Application.Features.SectionInstructors.Queries.GetList;

public class GetListSectionInstructorListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid SectionId { get; set; }
    public Guid InstructorId { get; set; }
}