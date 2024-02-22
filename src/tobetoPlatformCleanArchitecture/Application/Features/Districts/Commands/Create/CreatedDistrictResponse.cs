using Core.Application.Responses;

namespace Application.Features.Districts.Commands.Create;

public class CreatedDistrictResponse : IResponse
{
    public int Id { get; set; }
    public int ProvinceId { get; set; }
    public string Name { get; set; }
   
}