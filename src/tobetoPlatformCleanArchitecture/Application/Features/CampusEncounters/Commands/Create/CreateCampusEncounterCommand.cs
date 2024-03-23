using Application.Features.CampusEncounters.Constants;
using Application.Features.CampusEncounters.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CampusEncounters.Constants.CampusEncountersOperationClaims;

namespace Application.Features.CampusEncounters.Commands.Create;

public class CreateCampusEncounterCommand : IRequest<CreatedCampusEncounterResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Title { get; set; }
    public DateTime StartDateTime { get; set; }
    public string Location { get; set; }

    public string[] Roles => new[] { Admin, Write, CampusEncountersOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCampusEncounters";

    public class CreateCampusEncounterCommandHandler : IRequestHandler<CreateCampusEncounterCommand, CreatedCampusEncounterResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICampusEncounterRepository _campusEncounterRepository;
        private readonly CampusEncounterBusinessRules _campusEncounterBusinessRules;

        public CreateCampusEncounterCommandHandler(IMapper mapper, ICampusEncounterRepository campusEncounterRepository,
                                         CampusEncounterBusinessRules campusEncounterBusinessRules)
        {
            _mapper = mapper;
            _campusEncounterRepository = campusEncounterRepository;
            _campusEncounterBusinessRules = campusEncounterBusinessRules;
        }

        public async Task<CreatedCampusEncounterResponse> Handle(CreateCampusEncounterCommand request, CancellationToken cancellationToken)
        {
            CampusEncounter campusEncounter = _mapper.Map<CampusEncounter>(request);

            await _campusEncounterRepository.AddAsync(campusEncounter);

            CreatedCampusEncounterResponse response = _mapper.Map<CreatedCampusEncounterResponse>(campusEncounter);
            return response;
        }
    }
}