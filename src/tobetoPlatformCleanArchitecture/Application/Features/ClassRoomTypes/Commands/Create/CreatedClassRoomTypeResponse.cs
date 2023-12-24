using Core.Application.Responses;

namespace Application.Features.ClassRoomTypes.Commands.Create;

public class CreatedClassRoomTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}