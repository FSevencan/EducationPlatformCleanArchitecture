using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.ClassRoomTypeSections.Commands.Update;

public class UpdatedClassRoomTypeSectionResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ClassRoomTypeId { get; set; }
    public Guid SectionId { get; set; }
    public Section Section { get; set; }
    public ClassRoomType ClassRoomType { get; set; }
}