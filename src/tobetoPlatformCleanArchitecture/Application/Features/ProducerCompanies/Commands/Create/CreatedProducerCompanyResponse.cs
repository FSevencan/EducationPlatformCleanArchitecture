using Core.Application.Responses;

namespace Application.Features.ProducerCompanies.Commands.Create;

public class CreatedProducerCompanyResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}