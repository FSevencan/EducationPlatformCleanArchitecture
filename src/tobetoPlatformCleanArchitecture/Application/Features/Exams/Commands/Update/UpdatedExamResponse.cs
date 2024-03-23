using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Exams.Commands.Update;

public class UpdatedExamResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ClassRoomTypeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public int QuestionCount { get; set; }
    public string QuestionType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
  
}