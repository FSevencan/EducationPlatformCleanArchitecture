using Core.Application.Responses;

namespace Application.Features.Subscriptions.Commands.Update;

public class UpdatedSubscriptionResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public Guid ClassRoomTypeId { get; set; }
}