using Core.Application.Dtos;

namespace Application.Features.ClassRooms.Queries.GetList;

public class GetListClassRoomListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Branch { get; set; }
    public Guid ClassRoomTypeId { get; set; }
}