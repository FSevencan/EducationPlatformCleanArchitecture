using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.StudentSections.Queries.GetById;

public class GetByIdStudentSectionResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid SectionId { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public Section Section { get; set; }
}