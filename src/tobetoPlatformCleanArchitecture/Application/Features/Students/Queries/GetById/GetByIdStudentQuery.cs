using Application.Features.Students.Constants;
using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Students.Constants.StudentsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Students.Queries.GetById;

public class GetByIdStudentQuery : IRequest<GetByIdStudentResponse>/*, ISecuredRequest*/
{
    public int UserId { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdStudentQueryHandler : IRequestHandler<GetByIdStudentQuery, GetByIdStudentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly StudentBusinessRules _studentBusinessRules;

        public GetByIdStudentQueryHandler(IMapper mapper, IStudentRepository studentRepository, StudentBusinessRules studentBusinessRules)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
            _studentBusinessRules = studentBusinessRules;
        }

        public async Task<GetByIdStudentResponse> Handle(GetByIdStudentQuery request, CancellationToken cancellationToken)
        {
            Student? student = await _studentRepository.GetAsync(
               predicate: s => s.User.Id == request.UserId,
               include: s => s.Include(st => st.User)
                               .Include(st => st.StudentSkills)
                                    .ThenInclude(st => st.Skill)
                               .Include(st => st.Certificates)
                               .Include(st => st.StudentClassRooms)
                                   .ThenInclude(sc => sc.ClassRoom)
                                       .ThenInclude(c => c.ClassRoomType)
                                           .ThenInclude(ct => ct.ClassRoomTypeSection)
                                               .ThenInclude(cts => cts.Section)
                                               .ThenInclude(cts=> cts.Category),
                                                
                cancellationToken: cancellationToken);

            await _studentBusinessRules.StudentShouldExistWhenSelected(student);

            GetByIdStudentResponse response = _mapper.Map<GetByIdStudentResponse>(student);

            return response;
        }
    }
}