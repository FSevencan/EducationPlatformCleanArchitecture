using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.ClassRoomTypeSections.Commands.Create;

public class CreatedClassRoomTypeSectionResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ClassRoomTypeId { get; set; }
    public Guid SectionId { get; set; }
    public Section Section { get; set; }
    public ClassRoomType ClassRoomType { get; set; }
}