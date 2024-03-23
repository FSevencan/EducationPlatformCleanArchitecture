using Application.Features.StudentSkills.Constants;
using Application.Features.StudentSkills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.StudentSkills.Constants.StudentSkillsOperationClaims;

namespace Application.Features.StudentSkills.Queries.GetById;

public class GetByIdStudentSkillQuery : IRequest<GetByIdStudentSkillResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdStudentSkillQueryHandler : IRequestHandler<GetByIdStudentSkillQuery, GetByIdStudentSkillResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentSkillRepository _studentSkillRepository;
        private readonly StudentSkillBusinessRules _studentSkillBusinessRules;

        public GetByIdStudentSkillQueryHandler(IMapper mapper, IStudentSkillRepository studentSkillRepository, StudentSkillBusinessRules studentSkillBusinessRules)
        {
            _mapper = mapper;
            _studentSkillRepository = studentSkillRepository;
            _studentSkillBusinessRules = studentSkillBusinessRules;
        }

        public async Task<GetByIdStudentSkillResponse> Handle(GetByIdStudentSkillQuery request, CancellationToken cancellationToken)
        {
            StudentSkill? studentSkill = await _studentSkillRepository.GetAsync(predicate: ss => ss.Id == request.Id, cancellationToken: cancellationToken);
            await _studentSkillBusinessRules.StudentSkillShouldExistWhenSelected(studentSkill);

            GetByIdStudentSkillResponse response = _mapper.Map<GetByIdStudentSkillResponse>(studentSkill);
            return response;
        }
    }
}