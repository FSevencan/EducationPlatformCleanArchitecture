using Core.Application.Dtos;
using Domain.Entities;

namespace Application.Features.ClassRoomTypeSections.Queries.GetList;

public class GetListClassRoomTypeSectionListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid ClassRoomTypeId { get; set; }
    public Guid SectionId { get; set; }
   
}