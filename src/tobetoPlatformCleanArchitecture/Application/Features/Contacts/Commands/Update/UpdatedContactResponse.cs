using Core.Application.Responses;

namespace Application.Features.Contacts.Commands.Update;

public class UpdatedContactResponse : IResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public DateTime? ReadDate { get; set; }
}