using Core.Application.Responses;

namespace Application.Features.UserSurveys.Commands.Update;

public class UpdatedUserSurveyResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public Guid SurveyId { get; set; }
}