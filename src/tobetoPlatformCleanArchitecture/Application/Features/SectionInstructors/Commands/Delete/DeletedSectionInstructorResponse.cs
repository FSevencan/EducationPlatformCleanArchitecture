using Core.Application.Responses;

namespace Application.Features.SectionInstructors.Commands.Delete;

public class DeletedSectionInstructorResponse : IResponse
{
    public Guid Id { get; set; }
}