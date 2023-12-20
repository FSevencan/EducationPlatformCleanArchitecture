using Core.Application.Responses;

namespace Application.Features.Skills.Commands.Create;

public class CreatedSkillResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
}