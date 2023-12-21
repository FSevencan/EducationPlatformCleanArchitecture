using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.StudentClassRooms.Commands.Create;

public class CreatedStudentClassRoomResponse : IResponse
{
    public Guid Id { get; set; }
    public int StudentId { get; set; }
    public int ClassRoomId { get; set; }
   
}