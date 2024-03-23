using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Queries.GetListCertificateByUserId;
public class GetListCertificateByUserIdDto : IDto
{
    public Guid Id { get; set; }
    public string? Image { get; set; }
    public DateTime? CreatedDate { get; set; }
}
