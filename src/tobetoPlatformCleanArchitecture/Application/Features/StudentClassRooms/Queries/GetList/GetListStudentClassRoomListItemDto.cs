using Core.Application.Dtos;
using Domain.Entities;

namespace Application.Features.StudentClassRooms.Queries.GetList;

public class GetListStudentClassRoomListItemDto : IDto
{
    public Guid Id { get; set; }
    public int StudentId { get; set; }
    public Guid ClassRoomId { get; set; }
  
}