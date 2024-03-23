using Application.Features.CampusEncounters.Constants;
using Application.Features.CampusEncounters.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CampusEncounters.Constants.CampusEncountersOperationClaims;

namespace Application.Features.CampusEncounters.Queries.GetById;

public class GetByIdCampusEncounterQuery : IRequest<GetByIdCampusEncounterResponse>
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCampusEncounterQueryHandler : IRequestHandler<GetByIdCampusEncounterQuery, GetByIdCampusEncounterResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICampusEncounterRepository _campusEncounterRepository;
        private readonly CampusEncounterBusinessRules _campusEncounterBusinessRules;

        public GetByIdCampusEncounterQueryHandler(IMapper mapper, ICampusEncounterRepository campusEncounterRepository, CampusEncounterBusinessRules campusEncounterBusinessRules)
        {
            _mapper = mapper;
            _campusEncounterRepository = campusEncounterRepository;
            _campusEncounterBusinessRules = campusEncounterBusinessRules;
        }

        public async Task<GetByIdCampusEncounterResponse> Handle(GetByIdCampusEncounterQuery request, CancellationToken cancellationToken)
        {
            CampusEncounter? campusEncounter = await _campusEncounterRepository.GetAsync(predicate: ce => ce.Id == request.Id, cancellationToken: cancellationToken);
            await _campusEncounterBusinessRules.CampusEncounterShouldExistWhenSelected(campusEncounter);

            GetByIdCampusEncounterResponse response = _mapper.Map<GetByIdCampusEncounterResponse>(campusEncounter);
            return response;
        }
    }
}