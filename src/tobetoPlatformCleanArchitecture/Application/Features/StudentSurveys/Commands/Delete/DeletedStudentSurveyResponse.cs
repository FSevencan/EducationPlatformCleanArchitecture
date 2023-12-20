using Core.Application.Responses;

namespace Application.Features.StudentSurveys.Commands.Delete;

public class DeletedStudentSurveyResponse : IResponse
{
    public Guid Id { get; set; }
}