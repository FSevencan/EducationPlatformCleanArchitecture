using Core.Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Questions.Queries.GetListByExamId;
public class GetListQuestionByExamIdDto: IDto
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public Guid ExamId { get; set; }

    public ICollection<GetListChoiceDto> Choices { get; set; }
}
