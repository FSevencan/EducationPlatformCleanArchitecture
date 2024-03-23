using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ClassRoomTypes.Queries.GetClassRoomTypeByUserId;
public class GetClassRoomTypeByUserIdResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}