using Core.Application.Responses;

namespace Application.Features.ClassRoomTypes.Queries.GetById;

public class GetByIdClassRoomTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}