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

namespace Application.Features.Students.Queries.GetListExamByUserId;
public class GetListExamByUserIdQuery : IRequest<GetListExamByUserIdResponse>
{
    public int UserId { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListExamByUserIdQueryHandler : IRequestHandler<GetListExamByUserIdQuery, GetListExamByUserIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public GetListExamByUserIdQueryHandler(IMapper mapper, IStudentRepository studentRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<GetListExamByUserIdResponse> Handle(GetListExamByUserIdQuery request, CancellationToken cancellationToken)
        {
            Student? student = await _studentRepository.GetAsync(
                predicate: s => s.UserId == request.UserId,
                include: s => s.Include(user => user.User)
                              .Include(c=>c.StudentClassRooms)
                              .ThenInclude(c=>c.ClassRoom)
                              .ThenInclude(cr=>cr.ClassRoomType)
                              .ThenInclude(ct=>ct.Exams)
                              .ThenInclude(e=>e.UserAnswers.Where(a=>a.UserId == request.UserId)),
                cancellationToken: cancellationToken);

            GetListExamByUserIdResponse response = _mapper.Map<GetListExamByUserIdResponse>(student);
            return response;
                              
        }
    }
}
