using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Likes.Commands.Update;

public class UpdatedLikeResponse : IResponse
{
    public Guid Id { get; set; }
    public int StudentId { get; set; }
    public Guid SectionId { get; set; }
    public bool IsActive { get; set; }  
}