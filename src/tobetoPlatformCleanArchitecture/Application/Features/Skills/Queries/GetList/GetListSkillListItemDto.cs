using Core.Application.Dtos;

namespace Application.Features.Skills.Queries.GetList;

public class GetListSkillListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
}