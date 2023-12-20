using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.StudentSurveys.Commands.Update;

public class UpdatedStudentSurveyResponse : IResponse
{
    public Guid Id { get; set; }
    public int StudentId { get; set; }
    public Guid SurveyId { get; set; }
    public Student Student { get; set; }
    public Survey Survey { get; set; }
}