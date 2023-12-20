using Core.Application.Responses;

namespace Application.Features.Skills.Commands.Delete;

public class DeletedSkillResponse : IResponse
{
    public Guid Id { get; set; }
}