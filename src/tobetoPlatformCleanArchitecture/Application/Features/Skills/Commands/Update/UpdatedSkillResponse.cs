using Core.Application.Responses;

namespace Application.Features.Skills.Commands.Update;

public class UpdatedSkillResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
}