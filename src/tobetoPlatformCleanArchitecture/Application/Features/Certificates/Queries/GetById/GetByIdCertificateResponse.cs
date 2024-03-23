using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Certificates.Queries.GetById;

public class GetByIdCertificateResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Image { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
}