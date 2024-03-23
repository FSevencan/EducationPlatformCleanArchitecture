using Core.Application.Dtos;
using Core.Security.Entities;

namespace Application.Features.Students.Queries.GetList;

public class GetListStudentListItemDto : IDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImageUrl { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string Biography { get; set; }
    public string? GithubUrl { get; set; }
    public string? LinkedinUrl { get; set; }
   
}