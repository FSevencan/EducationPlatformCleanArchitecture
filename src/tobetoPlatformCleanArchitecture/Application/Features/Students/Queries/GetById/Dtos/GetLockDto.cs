using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Queries.GetById.Dtos;
public class GetLockDto:IDto
{
    public Guid Id { get; set; }
}
