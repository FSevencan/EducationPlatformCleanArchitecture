using Core.Application.Responses;
using Core.Security.Entities;

namespace Application.Features.Instructors.Commands.Create;

public class CreatedInstructorResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImageUrl { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string About { get; set; }
    public string Title { get; set; }
   
}