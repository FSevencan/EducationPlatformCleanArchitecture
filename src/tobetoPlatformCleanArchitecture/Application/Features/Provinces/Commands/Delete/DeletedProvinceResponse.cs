using Core.Application.Responses;

namespace Application.Features.Provinces.Commands.Delete;

public class DeletedProvinceResponse : IResponse
{
    public Guid Id { get; set; }
}