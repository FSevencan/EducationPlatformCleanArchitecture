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

namespace Application.Features.StudentSkills.Commands.Update;

public class UpdateStudentSkillCommand : IRequest<UpdatedStudentSkillResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public int StudentId { get; set; }
    public Guid SkillId { get; set; }
    

    public string[] Roles => new[] { Admin, Write, StudentSkillsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStudentSkills";

    public class UpdateStudentSkillCommandHandler : IRequestHandler<UpdateStudentSkillCommand, UpdatedStudentSkillResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentSkillRepository _studentSkillRepository;
        private readonly StudentSkillBusinessRules _studentSkillBusinessRules;

        public UpdateStudentSkillCommandHandler(IMapper mapper, IStudentSkillRepository studentSkillRepository,
                                         StudentSkillBusinessRules studentSkillBusinessRules)
        {
            _mapper = mapper;
            _studentSkillRepository = studentSkillRepository;
            _studentSkillBusinessRules = studentSkillBusinessRules;
        }

        public async Task<UpdatedStudentSkillResponse> Handle(UpdateStudentSkillCommand request, CancellationToken cancellationToken)
        {
            StudentSkill? studentSkill = await _studentSkillRepository.GetAsync(predicate: ss => ss.Id == request.Id, cancellationToken: cancellationToken);
            await _studentSkillBusinessRules.StudentSkillShouldExistWhenSelected(studentSkill);
            studentSkill = _mapper.Map(request, studentSkill);

            await _studentSkillRepository.UpdateAsync(studentSkill!);

            UpdatedStudentSkillResponse response = _mapper.Map<UpdatedStudentSkillResponse>(studentSkill);
            return response;
        }
    }
}