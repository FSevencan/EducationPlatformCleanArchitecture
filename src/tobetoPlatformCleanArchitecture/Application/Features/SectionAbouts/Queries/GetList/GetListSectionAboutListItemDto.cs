using Core.Application.Dtos;

namespace Application.Features.SectionAbouts.Queries.GetList;

public class GetListSectionAboutListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid ProducerCompanyId { get; set; }
    public Guid SectionId { get; set; }
    public string? Text { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public TimeSpan? EstimatedDuration { get; set; }
}