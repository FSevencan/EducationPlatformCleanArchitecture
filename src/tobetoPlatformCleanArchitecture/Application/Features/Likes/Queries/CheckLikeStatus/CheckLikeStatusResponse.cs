using System;
using System.Collections.Generic;

namespace Application.Features.Likes.Queries.CheckLikeStatus;
public class CheckLikeStatusResponse
{
    public bool IsLiked { get; set; }
    public Guid? Id { get; set; }
}
