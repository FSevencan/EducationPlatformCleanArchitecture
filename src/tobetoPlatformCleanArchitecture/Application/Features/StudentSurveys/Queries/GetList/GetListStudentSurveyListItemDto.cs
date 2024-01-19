using Core.Application.Dtos;
using Domain.Entities;

namespace Application.Features.StudentSurveys.Queries.GetList;

public class GetListStudentSurveyListItemDto : IDto
{
    public Guid Id { get; set; }
    public int StudentId { get; set; }
    public Guid SurveyId { get; set; }

}