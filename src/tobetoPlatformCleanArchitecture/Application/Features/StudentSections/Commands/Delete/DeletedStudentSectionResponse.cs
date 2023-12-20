using Core.Application.Responses;

namespace Application.Features.StudentSections.Commands.Delete;

public class DeletedStudentSectionResponse : IResponse
{
    public Guid Id { get; set; }
}