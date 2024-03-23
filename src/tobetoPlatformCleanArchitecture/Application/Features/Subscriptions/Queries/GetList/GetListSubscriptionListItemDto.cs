using Core.Application.Dtos;

namespace Application.Features.Subscriptions.Queries.GetList;

public class GetListSubscriptionListItemDto : IDto
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public Guid ClassRoomTypeId { get; set; }
}