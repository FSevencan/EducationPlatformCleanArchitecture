using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Queries.GetListExamByUserId;
public class GetListUserAnswersDto:IDto
{
    public Guid Id { get; set; } 
    public int CorrectCount { get; set; }
    public int WrongCount { get; set; }
    public int EmptyCount { get; set; }
    public int? TotalScore { get; set; }
}
