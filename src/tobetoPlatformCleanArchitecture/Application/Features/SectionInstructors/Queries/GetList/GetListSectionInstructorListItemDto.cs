using Core.Application.Dtos;
using Domain.Entities;

namespace Application.Features.SectionInstructors.Queries.GetList;

public class GetListSectionInstructorListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid SectionId { get; set; }
    public int InstructorId { get; set; }
   
}