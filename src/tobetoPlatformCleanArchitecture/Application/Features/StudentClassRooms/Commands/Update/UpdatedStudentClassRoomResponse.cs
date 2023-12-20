using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.StudentClassRooms.Commands.Update;

public class UpdatedStudentClassRoomResponse : IResponse
{
    public Guid Id { get; set; }
    public int StudentId { get; set; }
    public int ClassRoomId { get; set; }
    public Student Student { get; set; }
    public ClassRoom ClassRoom { get; set; }
}