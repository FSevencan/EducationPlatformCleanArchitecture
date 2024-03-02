using Application.Features.StudentSkills.Constants;
using Application.Features.StudentSkills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.StudentSkills.Constants.StudentSkillsOperationClaims;
using Application.Services.Students;
using Application.Features.Students.Rules;

namespace Application.Features.StudentSkills.Commands.Create;

public class CreateStudentSkillCommand : IRequest<CreatedStudentSkillResponse>/*, ISecuredRequest*/, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int UserId { get; set; }
    public ICollection<Guid> Skills { get; set; }

    public string[] Roles => new[] { Admin, Write, StudentSkillsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStudentSkills";

    public class CreateStudentSkillCommandHandler : IRequestHandler<CreateStudentSkillCommand, CreatedStudentSkillResponse>
    {
        private readonly IStudentSkillRepository _studentSkillRepository;
        private readonly IStudentsService _studentsService;
        private readonly StudentSkillBusinessRules _studentSkillBusinessRules;
        private readonly StudentBusinessRules _studentBusinessRules;

        public CreateStudentSkillCommandHandler(IMapper mapper, IStudentSkillRepository studentSkillRepository, IStudentsService studentsService, StudentSkillBusinessRules studentSkillBusinessRules, StudentBusinessRules studentBusinessRules)
        {
            _studentSkillRepository = studentSkillRepository;
            _studentSkillBusinessRules = studentSkillBusinessRules;
            _studentsService = studentsService;
            _studentBusinessRules = studentBusinessRules;
        }

        public async Task<CreatedStudentSkillResponse> Handle(CreateStudentSkillCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentsService.GetAsync(x => x.UserId == request.UserId);

            await _studentBusinessRules.StudentShouldExistWhenSelected(student);

            var studentSkills = request.Skills.Select(skillId => new StudentSkill
            {
                StudentId = student.Id,
                SkillId = skillId
            }).ToList();

            await _studentSkillRepository.AddRangeAsync(studentSkills);          

            CreatedStudentSkillResponse response = new CreatedStudentSkillResponse
            {
                StudentId = student.Id,
                Skills = request.Skills
            };
            return response;
        }
    }
}
