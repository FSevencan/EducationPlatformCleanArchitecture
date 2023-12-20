using Core.Application.Responses;

namespace Application.Features.ClassRooms.Commands.Delete;

public class DeletedClassRoomResponse : IResponse
{
    public Guid Id { get; set; }
}