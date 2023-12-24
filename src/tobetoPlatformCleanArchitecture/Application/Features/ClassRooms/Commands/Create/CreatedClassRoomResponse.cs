using Core.Application.Responses;

namespace Application.Features.ClassRooms.Commands.Create;

public class CreatedClassRoomResponse : IResponse
{
    public Guid Id { get; set; }
    public string Branch { get; set; }
    public Guid ClassRoomTypeId { get; set; }
}