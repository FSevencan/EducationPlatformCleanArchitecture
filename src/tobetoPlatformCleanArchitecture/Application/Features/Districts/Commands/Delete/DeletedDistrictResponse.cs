using Core.Application.Responses;

namespace Application.Features.Districts.Commands.Delete;

public class DeletedDistrictResponse : IResponse
{
    public Guid Id { get; set; }
}