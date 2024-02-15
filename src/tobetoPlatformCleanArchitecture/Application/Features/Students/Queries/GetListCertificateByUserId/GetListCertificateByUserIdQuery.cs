using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.Students.Constants.StudentsOperationClaims;


namespace Application.Features.Students.Queries.GetListCertificateByUserId;
public class GetListCertificateByUserIdQuery : IRequest<GetListCertificateByUserIdResponse>
{

    public int UserId { get; set; }

    public string[] Roles => new[] { Admin, Read };


    public class GetListCeriticateByUserIdQueryHandler : IRequestHandler<GetListCertificateByUserIdQuery, GetListCertificateByUserIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public GetListCeriticateByUserIdQueryHandler(IMapper mapper, IStudentRepository studentRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<GetListCertificateByUserIdResponse> Handle(GetListCertificateByUserIdQuery request, CancellationToken cancellationToken)
        {
            Student? student = await _studentRepository.GetAsync(
                predicate: s => s.UserId == request.UserId,
                include: s => s.Include(user => user.User)
                               .Include(c => c.Certificates),
                               
                cancellationToken: cancellationToken);

            GetListCertificateByUserIdResponse response = _mapper.Map<GetListCertificateByUserIdResponse>(student);
            return response;

        }
    }


}
