using Core.Application.Responses;

namespace Application.Features.Skills.Queries.GetById;

public class GetByIdSkillResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
}