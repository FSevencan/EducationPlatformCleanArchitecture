using Core.Application.Responses;

namespace Application.Features.Surveys.Commands.Update;

public class UpdatedSurveyResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string FormUrl { get; set; }

}