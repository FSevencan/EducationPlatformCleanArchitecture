using Core.Application.Dtos;

namespace Application.Features.ProducerCompanies.Queries.GetList;

public class GetListProducerCompanyListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}