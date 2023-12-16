using Core.Application.Responses;

namespace Application.Features.AppUsers.Commands.Create;

public class CreatedAppUserResponse : IResponse
{

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }
}