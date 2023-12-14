using Core.Application.Responses;

namespace Application.Features.ApplicationEducations.Commands.Delete;

public class DeletedApplicationEducationResponse : IResponse
{
    public Guid Id { get; set; }
}