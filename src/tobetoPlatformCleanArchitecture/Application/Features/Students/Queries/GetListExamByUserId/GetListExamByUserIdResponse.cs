using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Queries.GetListExamByUserId;
public class GetListExamByUserIdResponse : IResponse
{
    public ICollection<GetListExamByUserIdDto> Exams { get; set; }
}
