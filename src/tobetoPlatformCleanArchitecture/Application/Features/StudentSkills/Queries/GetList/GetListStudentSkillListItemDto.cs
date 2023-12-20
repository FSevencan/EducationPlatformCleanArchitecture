using Core.Application.Dtos;
using Domain.Entities;

namespace Application.Features.StudentSkills.Queries.GetList;

public class GetListStudentSkillListItemDto : IDto
{
    public Guid Id { get; set; }
    public int StudentId { get; set; }
    public Guid SkillId { get; set; }
    public Student Student { get; set; }
    public Skill Skill { get; set; }
}