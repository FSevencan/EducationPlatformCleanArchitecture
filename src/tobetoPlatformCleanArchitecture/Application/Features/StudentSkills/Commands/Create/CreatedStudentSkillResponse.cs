using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.StudentSkills.Commands.Create;

public class CreatedStudentSkillResponse : IResponse
{
    public int StudentId { get; set; }
    public ICollection<Guid> Skills { get; set; }    
}