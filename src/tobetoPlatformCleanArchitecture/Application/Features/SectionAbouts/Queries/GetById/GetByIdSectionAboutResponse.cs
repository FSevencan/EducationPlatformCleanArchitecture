using Core.Application.Responses;

namespace Application.Features.SectionAbouts.Queries.GetById;

public class GetByIdSectionAboutResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ProducerCompanyId { get; set; }
    public Guid SectionId { get; set; }
    public Guid LanguageId { get; set; }
    public string? Text { get; set; }
    public double EstimatedDuration { get; set; }
    
}