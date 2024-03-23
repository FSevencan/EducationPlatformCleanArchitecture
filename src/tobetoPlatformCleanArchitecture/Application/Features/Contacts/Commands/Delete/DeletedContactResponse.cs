using Core.Application.Responses;

namespace Application.Features.Contacts.Commands.Delete;

public class DeletedContactResponse : IResponse
{
    public Guid Id { get; set; }
}