using Core.Application.Responses;

namespace Application.Features.SectionInstructors.Queries.GetById;

public class GetByIdSectionInstructorResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid SectionId { get; set; }
    public Guid InstructorId { get; set; }
}