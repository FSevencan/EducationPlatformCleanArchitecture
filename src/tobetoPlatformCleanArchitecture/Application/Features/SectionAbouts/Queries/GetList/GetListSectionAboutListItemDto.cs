using Core.Application.Dtos;

namespace Application.Features.SectionAbouts.Queries.GetList;

public class GetListSectionAboutListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? Text { get; set; }
    public double EstimatedDuration { get; set; }

}