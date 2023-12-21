using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.StudentSections.Commands.Update;

public class UpdatedStudentSectionResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid SectionId { get; set; }
    public int StudentId { get; set; }
   
}