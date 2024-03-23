using Application.Features.Students.Constants;
using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Students.Constants.StudentsOperationClaims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Core.Security.Extensions;

namespace Application.Features.Students.Queries.GetById;

public class GetByUserIdStudentLockQuery : IRequest<GetByUserIdStudentLockResponse>/*, ISecuredRequest*/
{
    public int UserId { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByUserIdStudentLockQueryHandler : IRequestHandler<GetByUserIdStudentLockQuery, GetByUserIdStudentLockResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly StudentBusinessRules _studentBusinessRules;

        public GetByUserIdStudentLockQueryHandler(IMapper mapper, IStudentRepository studentRepository, StudentBusinessRules studentBusinessRules, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
            _studentBusinessRules = studentBusinessRules;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<GetByUserIdStudentLockResponse> Handle(GetByUserIdStudentLockQuery request, CancellationToken cancellationToken)
        {
            
            Student? student = await _studentRepository.GetAsync(
               predicate: s => s.User.Id == request.UserId,
               include: s => s.Include(st => st.User)
                               .Include(st => st.StudentClassRooms)
                                   .ThenInclude(sc => sc.ClassRoom)
                                       .ThenInclude(c => c.ClassRoomType)
                                           .ThenInclude(ct => ct.ClassRoomTypeSection)
                                               .ThenInclude(cts => cts.Section),
                                                
                cancellationToken: cancellationToken);

            await _studentBusinessRules.StudentShouldExistWhenSelected(student);

            GetByUserIdStudentLockResponse response = _mapper.Map<GetByUserIdStudentLockResponse>(student);

            return response;
        }
    }
}