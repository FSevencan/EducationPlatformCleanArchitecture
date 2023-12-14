using Core.Application.Responses;

namespace Application.Features.SectionInstructors.Commands.Update;

public class UpdatedSectionInstructorResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid SectionId { get; set; }
    public Guid InstructorId { get; set; }
}