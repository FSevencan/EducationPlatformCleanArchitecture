using Core.Application.Responses;

namespace Application.Features.ProducerCompanies.Commands.Update;

public class UpdatedProducerCompanyResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}