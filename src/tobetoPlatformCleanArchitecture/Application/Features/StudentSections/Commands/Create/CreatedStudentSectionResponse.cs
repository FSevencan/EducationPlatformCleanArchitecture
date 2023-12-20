using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.StudentSections.Commands.Create;

public class CreatedStudentSectionResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid SectionId { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public Section Section { get; set; }
}