using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Likes.Queries.CheckLikeStatus;
public class CheckLikeStatusResponse
{
    public bool IsActive { get; set; }
    public Guid Id { get; set; }
}
