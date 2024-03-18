using Core.Application.Responses;

namespace Application.Features.Likes.Commands.Delete;

public class DeletedLikeResponse : IResponse
{
    public Guid Id { get; set; }
}