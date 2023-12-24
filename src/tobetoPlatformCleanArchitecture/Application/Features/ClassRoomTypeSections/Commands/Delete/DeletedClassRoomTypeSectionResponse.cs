using Core.Application.Responses;

namespace Application.Features.ClassRoomTypeSections.Commands.Delete;

public class DeletedClassRoomTypeSectionResponse : IResponse
{
    public Guid Id { get; set; }
}