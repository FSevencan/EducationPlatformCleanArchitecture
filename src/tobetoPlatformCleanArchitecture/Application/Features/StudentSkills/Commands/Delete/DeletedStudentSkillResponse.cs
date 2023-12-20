using Core.Application.Responses;

namespace Application.Features.StudentSkills.Commands.Delete;

public class DeletedStudentSkillResponse : IResponse
{
    public Guid Id { get; set; }
}