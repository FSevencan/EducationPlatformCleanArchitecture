using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.StudentClassRooms.Commands.Create;

public class CreatedStudentClassRoomResponse : IResponse
{
   
    public int StudentId { get; set; }
    public Guid ClassRoomId { get; set; }
   
}