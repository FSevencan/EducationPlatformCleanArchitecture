using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Likes.Commands.Create;

public class CreatedLikeResponse : IResponse
{
    public Guid Id { get; set; }
    public int StudentId { get; set; }
    public Guid SectionId { get; set; } 
}