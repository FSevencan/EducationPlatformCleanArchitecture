using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.StudentSkills.Commands.Update;

public class UpdatedStudentSkillResponse : IResponse
{
    public Guid Id { get; set; }
    public int StudentId { get; set; }
    public Guid SkillId { get; set; }
    public Student Student { get; set; }
    public Skill Skill { get; set; }
}