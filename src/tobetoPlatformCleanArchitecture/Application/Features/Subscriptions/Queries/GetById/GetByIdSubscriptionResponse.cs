using Core.Application.Responses;

namespace Application.Features.Subscriptions.Queries.GetById;

public class GetByIdSubscriptionResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public Guid ClassRoomTypeId { get; set; }
}