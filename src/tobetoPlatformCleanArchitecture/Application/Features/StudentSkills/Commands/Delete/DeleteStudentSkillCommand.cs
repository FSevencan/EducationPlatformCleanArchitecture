using Application.Features.StudentSkills.Constants;
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

namespace Application.Features.StudentSkills.Commands.Delete;

public class DeleteStudentSkillCommand : IRequest<DeletedStudentSkillResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, StudentSkillsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStudentSkills";

    public class DeleteStudentSkillCommandHandler : IRequestHandler<DeleteStudentSkillCommand, DeletedStudentSkillResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentSkillRepository _studentSkillRepository;
        private readonly StudentSkillBusinessRules _studentSkillBusinessRules;

        public DeleteStudentSkillCommandHandler(IMapper mapper, IStudentSkillRepository studentSkillRepository,
                                         StudentSkillBusinessRules studentSkillBusinessRules)
        {
            _mapper = mapper;
            _studentSkillRepository = studentSkillRepository;
            _studentSkillBusinessRules = studentSkillBusinessRules;
        }

        public async Task<DeletedStudentSkillResponse> Handle(DeleteStudentSkillCommand request, CancellationToken cancellationToken)
        {
            StudentSkill? studentSkill = await _studentSkillRepository.GetAsync(predicate: ss => ss.Id == request.Id, cancellationToken: cancellationToken);
            await _studentSkillBusinessRules.StudentSkillShouldExistWhenSelected(studentSkill);

            await _studentSkillRepository.DeleteAsync(studentSkill!);

            DeletedStudentSkillResponse response = _mapper.Map<DeletedStudentSkillResponse>(studentSkill);
            return response;
        }
    }
}