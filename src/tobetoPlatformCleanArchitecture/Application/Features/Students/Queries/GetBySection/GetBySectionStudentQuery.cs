using Application.Features.Students.Constants;
using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Students.Constants.StudentsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Students.Queries.GetBySection;

public class GetBySectionStudentQuery : IRequest<GetBySectionStudentResponse>/*, ISecuredRequest*/
{
    public int UserId { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdStudentQueryHandler : IRequestHandler<GetBySectionStudentQuery, GetBySectionStudentResponse>
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

        public async Task<GetBySectionStudentResponse> Handle(GetBySectionStudentQuery request, CancellationToken cancellationToken)
        {
            Student? student = await _studentRepository.GetAsync(
               predicate: s => s.User.Id == request.UserId,
               include: s => s.Include(st => st.User)
                               .Include(st => st.StudentClassRooms)
                                   .ThenInclude(sc => sc.ClassRoom)
                                       .ThenInclude(c => c.ClassRoomType)
                                           .ThenInclude(ct => ct.ClassRoomTypeSection)
                                               .ThenInclude(cts => cts.Section)
                                               .ThenInclude(s=>s.SectionCourses)
                                               .ThenInclude(sc=>sc.Course)
                                               .ThenInclude(c=>c.SectionCourses)
                                               .ThenInclude(sc=>sc.Section)
                                                .ThenInclude(cts=> cts.Category)
                                                .ThenInclude(cts => cts.Sections)
                                                .ThenInclude(s => s.SectionInstructors)
                                                .ThenInclude(si => si.Instructor)
                                                .ThenInclude(si=>si.User)
                                               ,
                                                
                cancellationToken: cancellationToken);

            await _studentBusinessRules.StudentShouldExistWhenSelected(student);

            GetBySectionStudentResponse response = _mapper.Map<GetBySectionStudentResponse>(student);

            return response;
        }
    }
}