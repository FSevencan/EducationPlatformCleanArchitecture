using Core.Application.Responses;

namespace Application.Features.UserSurveys.Commands.Create;

public class CreatedUserSurveyResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public Guid SurveyId { get; set; }
}