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

namespace Application.Features.CampusEncounters.Commands.Update;

public class UpdateCampusEncounterCommand : IRequest<UpdatedCampusEncounterResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime StartDateTime { get; set; }
    public string Location { get; set; }

    public string[] Roles => new[] { Admin, Write, CampusEncountersOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCampusEncounters";

    public class UpdateCampusEncounterCommandHandler : IRequestHandler<UpdateCampusEncounterCommand, UpdatedCampusEncounterResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICampusEncounterRepository _campusEncounterRepository;
        private readonly CampusEncounterBusinessRules _campusEncounterBusinessRules;

        public UpdateCampusEncounterCommandHandler(IMapper mapper, ICampusEncounterRepository campusEncounterRepository,
                                         CampusEncounterBusinessRules campusEncounterBusinessRules)
        {
            _mapper = mapper;
            _campusEncounterRepository = campusEncounterRepository;
            _campusEncounterBusinessRules = campusEncounterBusinessRules;
        }

        public async Task<UpdatedCampusEncounterResponse> Handle(UpdateCampusEncounterCommand request, CancellationToken cancellationToken)
        {
            CampusEncounter? campusEncounter = await _campusEncounterRepository.GetAsync(predicate: ce => ce.Id == request.Id, cancellationToken: cancellationToken);
            await _campusEncounterBusinessRules.CampusEncounterShouldExistWhenSelected(campusEncounter);
            campusEncounter = _mapper.Map(request, campusEncounter);

            await _campusEncounterRepository.UpdateAsync(campusEncounter!);

            UpdatedCampusEncounterResponse response = _mapper.Map<UpdatedCampusEncounterResponse>(campusEncounter);
            return response;
        }
    }
}