using Core.Application.Responses;

namespace Application.Features.ProducerCompanies.Commands.Delete;

public class DeletedProducerCompanyResponse : IResponse
{
    public Guid Id { get; set; }
}