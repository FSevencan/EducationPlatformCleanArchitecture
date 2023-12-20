using Core.Application.Dtos;
using Domain.Entities;

namespace Application.Features.StudentSections.Queries.GetList;

public class GetListStudentSectionListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid SectionId { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public Section Section { get; set; }
}