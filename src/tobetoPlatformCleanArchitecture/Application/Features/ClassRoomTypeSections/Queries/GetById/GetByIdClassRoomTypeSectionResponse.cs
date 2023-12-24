using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.ClassRoomTypeSections.Queries.GetById;

public class GetByIdClassRoomTypeSectionResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ClassRoomTypeId { get; set; }
    public Guid SectionId { get; set; }
    
}