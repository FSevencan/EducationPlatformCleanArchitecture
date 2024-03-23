using Application.Features.Skills.Constants;
using Application.Features.Skills.Constants;
using Application.Features.Skills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Skills.Constants.SkillsOperationClaims;

namespace Application.Features.Skills.Commands.Delete;

public class DeleteSkillCommand : IRequest<DeletedSkillResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, SkillsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSkills";

    public class DeleteSkillCommandHandler : IRequestHandler<DeleteSkillCommand, DeletedSkillResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISkillRepository _skillRepository;
        private readonly SkillBusinessRules _skillBusinessRules;

        public DeleteSkillCommandHandler(IMapper mapper, ISkillRepository skillRepository,
                                         SkillBusinessRules skillBusinessRules)
        {
            _mapper = mapper;
            _skillRepository = skillRepository;
            _skillBusinessRules = skillBusinessRules;
        }

        public async Task<DeletedSkillResponse> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            Skill? skill = await _skillRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _skillBusinessRules.SkillShouldExistWhenSelected(skill);

            await _skillRepository.DeleteAsync(skill!);

            DeletedSkillResponse response = _mapper.Map<DeletedSkillResponse>(skill);
            return response;
        }
    }
}