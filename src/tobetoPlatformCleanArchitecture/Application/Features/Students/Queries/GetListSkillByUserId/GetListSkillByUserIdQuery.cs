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

namespace Application.Features.Students.Queries.GetListSkillByUserId;
public class GetListSkillByUserIdQuery : IRequest<GetListSkillByUserIdResponse>
{
    public int UserId { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListSkillByUserIdQueryHandler : IRequestHandler<GetListSkillByUserIdQuery, GetListSkillByUserIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public GetListSkillByUserIdQueryHandler(IMapper mapper, IStudentRepository studentRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<GetListSkillByUserIdResponse> Handle(GetListSkillByUserIdQuery request, CancellationToken cancellationToken)
        {
            Student? student = await _studentRepository.GetAsync(
                predicate: s => s.UserId == request.UserId,
                include: s => s.Include(user => user.User)
                               .Include(ss => ss.StudentSkills)
                               .ThenInclude(skill => skill.Skill),
                cancellationToken: cancellationToken);

            GetListSkillByUserIdResponse response = _mapper.Map<GetListSkillByUserIdResponse>(student);
            return response;
                              
        }
    }
}
