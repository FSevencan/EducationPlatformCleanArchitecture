using Core.Application.Responses;

namespace Application.Features.ProducerCompanies.Queries.GetById;

public class GetByIdProducerCompanyResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}