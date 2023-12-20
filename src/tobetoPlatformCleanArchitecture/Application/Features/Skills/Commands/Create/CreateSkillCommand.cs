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

namespace Application.Features.Skills.Commands.Create;

public class CreateSkillCommand : IRequest<CreatedSkillResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public int Level { get; set; }

    public string[] Roles => new[] { Admin, Write, SkillsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSkills";

    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, CreatedSkillResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISkillRepository _skillRepository;
        private readonly SkillBusinessRules _skillBusinessRules;

        public CreateSkillCommandHandler(IMapper mapper, ISkillRepository skillRepository,
                                         SkillBusinessRules skillBusinessRules)
        {
            _mapper = mapper;
            _skillRepository = skillRepository;
            _skillBusinessRules = skillBusinessRules;
        }

        public async Task<CreatedSkillResponse> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            Skill skill = _mapper.Map<Skill>(request);

            await _skillRepository.AddAsync(skill);

            CreatedSkillResponse response = _mapper.Map<CreatedSkillResponse>(skill);
            return response;
        }
    }
}