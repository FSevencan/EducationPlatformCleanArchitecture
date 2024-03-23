using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.SectionInstructors.Commands.Create;

public class CreatedSectionInstructorResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid SectionId { get; set; }
    public Guid InstructorId { get; set; }
   
}