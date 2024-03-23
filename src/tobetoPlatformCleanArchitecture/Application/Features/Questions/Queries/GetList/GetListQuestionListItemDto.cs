using Core.Application.Dtos;
using Domain.Entities;

namespace Application.Features.Questions.Queries.GetList;

public class GetListQuestionListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public Guid ExamId { get; set; }
   
}