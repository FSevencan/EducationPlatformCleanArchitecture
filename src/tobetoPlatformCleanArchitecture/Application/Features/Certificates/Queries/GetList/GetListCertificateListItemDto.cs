using Core.Application.Dtos;
using Domain.Entities;

namespace Application.Features.Certificates.Queries.GetList;

public class GetListCertificateListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? Image { get; set; }
    public int StudentId { get; set; }
   
}