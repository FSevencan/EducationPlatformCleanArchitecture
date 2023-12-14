using Core.Application.Responses;

namespace Application.Features.UserSurveys.Queries.GetById;

public class GetByIdUserSurveyResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public Guid SurveyId { get; set; }
}