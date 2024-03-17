using Core.Application.Dtos;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Subscriptions.Queries.GetSubscriptionsByUserId;
public class GetSubscriptionByUserIdResponse : IDto
{
    public Guid Id { get; set; }
    public Guid ClassRoomTypeId { get; set; }
    public string ClassRoomTypeName { get; set; }
}
