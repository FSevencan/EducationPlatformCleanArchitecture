using Application.Features.Skills.Constants;
using Application.Features.Skills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Skills.Constants.SkillsOperationClaims;

namespace Application.Features.Skills.Queries.GetById;

public class GetByIdSkillQuery : IRequest<GetByIdSkillResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdSkillQueryHandler : IRequestHandler<GetByIdSkillQuery, GetByIdSkillResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISkillRepository _skillRepository;
        private readonly SkillBusinessRules _skillBusinessRules;

        public GetByIdSkillQueryHandler(IMapper mapper, ISkillRepository skillRepository, SkillBusinessRules skillBusinessRules)
        {
            _mapper = mapper;
            _skillRepository = skillRepository;
            _skillBusinessRules = skillBusinessRules;
        }

        public async Task<GetByIdSkillResponse> Handle(GetByIdSkillQuery request, CancellationToken cancellationToken)
        {
            Skill? skill = await _skillRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _skillBusinessRules.SkillShouldExistWhenSelected(skill);

            GetByIdSkillResponse response = _mapper.Map<GetByIdSkillResponse>(skill);
            return response;
        }
    }
}