using Core.Application.Responses;

namespace Application.Features.ClassRoomTypes.Commands.Delete;

public class DeletedClassRoomTypeResponse : IResponse
{
    public Guid Id { get; set; }
}