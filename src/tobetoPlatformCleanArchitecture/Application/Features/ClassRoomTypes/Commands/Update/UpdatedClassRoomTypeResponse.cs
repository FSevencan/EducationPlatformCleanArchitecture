using Core.Application.Responses;

namespace Application.Features.ClassRoomTypes.Commands.Update;

public class UpdatedClassRoomTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}