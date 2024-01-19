using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.StudentClassRooms.Queries.GetById;

public class GetByIdStudentClassRoomResponse : IResponse
{
    public Guid Id { get; set; }
    public int StudentId { get; set; }
    public int ClassRoomId { get; set; }
    
}