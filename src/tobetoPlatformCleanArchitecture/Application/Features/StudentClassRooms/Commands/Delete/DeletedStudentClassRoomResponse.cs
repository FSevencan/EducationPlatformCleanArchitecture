using Core.Application.Responses;

namespace Application.Features.StudentClassRooms.Commands.Delete;

public class DeletedStudentClassRoomResponse : IResponse
{
    public Guid Id { get; set; }
}