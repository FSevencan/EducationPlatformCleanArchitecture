using Core.Application.Dtos;

namespace Application.Features.ClassRoomTypes.Queries.GetList;

public class GetListClassRoomTypeListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}