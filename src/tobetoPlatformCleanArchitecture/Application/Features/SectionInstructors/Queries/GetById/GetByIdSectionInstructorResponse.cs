using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.SectionInstructors.Queries.GetById;

public class GetByIdSectionInstructorResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid SectionId { get; set; }
    public Guid InstructorId { get; set; }
    public Section Section { get; set; }
    public Instructor Instructor { get; set; }
}