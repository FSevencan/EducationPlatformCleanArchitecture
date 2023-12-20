using Core.Application.Responses;

namespace Application.Features.ClassRooms.Queries.GetById;

public class GetByIdClassRoomResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}