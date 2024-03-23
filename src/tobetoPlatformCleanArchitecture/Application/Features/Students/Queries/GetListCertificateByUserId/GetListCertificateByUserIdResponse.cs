using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Queries.GetListCertificateByUserId;
public class GetListCertificateByUserIdResponse : IResponse
{
    public ICollection<GetListCertificateByUserIdDto> Certificates { get; set; }

}
