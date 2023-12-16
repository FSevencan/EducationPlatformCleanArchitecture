using Core.Application.Responses;

namespace Application.Features.AppUsers.Commands.Delete;

public class DeletedAppUserResponse : IResponse
{
    public int Id { get; set; }
}