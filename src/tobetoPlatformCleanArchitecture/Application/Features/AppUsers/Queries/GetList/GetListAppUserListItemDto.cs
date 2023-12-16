using Core.Application.Dtos;

namespace Application.Features.AppUsers.Queries.GetList;

public class GetListAppUserListItemDto : IDto
{
    public int Id { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string About { get; set; }
    public string? GithubUrl { get; set; }
    public string? LinkedinUrl { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }
}