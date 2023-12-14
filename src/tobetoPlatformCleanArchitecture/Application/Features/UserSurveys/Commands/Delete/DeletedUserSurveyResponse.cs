using Core.Application.Responses;

namespace Application.Features.UserSurveys.Commands.Delete;

public class DeletedUserSurveyResponse : IResponse
{
    public Guid Id { get; set; }
}