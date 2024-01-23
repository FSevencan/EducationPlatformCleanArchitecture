using Core.Application.Responses;
using Core.Security.Entities;

namespace Application.Features.Students.Commands.Update;

public class UpdatedStudentResponse : IResponse
{

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? ImageUrl { get; set; }
    public string Email { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Biography { get; set; }
    public string? GithubUrl { get; set; }
    public string? LinkedinUrl { get; set; }

    public string? TwitterUrl { get; set; }
}