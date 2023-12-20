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

namespace Application.Features.StudentSkills.Commands.Create;

public class CreateStudentSkillCommand : IRequest<CreatedStudentSkillResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int StudentId { get; set; }
    public Guid SkillId { get; set; }
    public Student Student { get; set; }
    public Skill Skill { get; set; }

    public string[] Roles => new[] { Admin, Write, StudentSkillsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStudentSkills";

    public class CreateStudentSkillCommandHandler : IRequestHandler<CreateStudentSkillCommand, CreatedStudentSkillResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentSkillRepository _studentSkillRepository;
        private readonly StudentSkillBusinessRules _studentSkillBusinessRules;

        public CreateStudentSkillCommandHandler(IMapper mapper, IStudentSkillRepository studentSkillRepository,
                                         StudentSkillBusinessRules studentSkillBusinessRules)
        {
            _mapper = mapper;
            _studentSkillRepository = studentSkillRepository;
            _studentSkillBusinessRules = studentSkillBusinessRules;
        }

        public async Task<CreatedStudentSkillResponse> Handle(CreateStudentSkillCommand request, CancellationToken cancellationToken)
        {
            StudentSkill studentSkill = _mapper.Map<StudentSkill>(request);

            await _studentSkillRepository.AddAsync(studentSkill);

            CreatedStudentSkillResponse response = _mapper.Map<CreatedStudentSkillResponse>(studentSkill);
            return response;
        }
    }
}