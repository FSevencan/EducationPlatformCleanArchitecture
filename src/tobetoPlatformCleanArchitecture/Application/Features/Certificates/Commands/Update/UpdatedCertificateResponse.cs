using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Certificates.Commands.Update;

public class UpdatedCertificateResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Image { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
}