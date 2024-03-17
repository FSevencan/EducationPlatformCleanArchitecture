using Core.Application.Responses;

namespace Application.Features.Subscriptions.Commands.Create;

public class CreatedSubscriptionResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public Guid ClassRoomTypeId { get; set; }
}