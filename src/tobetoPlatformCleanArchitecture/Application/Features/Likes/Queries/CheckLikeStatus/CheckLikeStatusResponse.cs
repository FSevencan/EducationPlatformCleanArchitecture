using System;
using System.Collections.Generic;

namespace Application.Features.Likes.Queries.CheckLikeStatus;
public class CheckLikeStatusResponse
{
    public bool IsActive { get; set; }
    public Guid Id { get; set; }
}
