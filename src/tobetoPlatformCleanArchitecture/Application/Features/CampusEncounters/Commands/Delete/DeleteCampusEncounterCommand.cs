using Application.Features.CampusEncounters.Constants;
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

namespace Application.Features.CampusEncounters.Commands.Delete;

public class DeleteCampusEncounterCommand : IRequest<DeletedCampusEncounterResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CampusEncountersOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCampusEncounters";

    public class DeleteCampusEncounterCommandHandler : IRequestHandler<DeleteCampusEncounterCommand, DeletedCampusEncounterResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICampusEncounterRepository _campusEncounterRepository;
        private readonly CampusEncounterBusinessRules _campusEncounterBusinessRules;

        public DeleteCampusEncounterCommandHandler(IMapper mapper, ICampusEncounterRepository campusEncounterRepository,
                                         CampusEncounterBusinessRules campusEncounterBusinessRules)
        {
            _mapper = mapper;
            _campusEncounterRepository = campusEncounterRepository;
            _campusEncounterBusinessRules = campusEncounterBusinessRules;
        }

        public async Task<DeletedCampusEncounterResponse> Handle(DeleteCampusEncounterCommand request, CancellationToken cancellationToken)
        {
            CampusEncounter? campusEncounter = await _campusEncounterRepository.GetAsync(predicate: ce => ce.Id == request.Id, cancellationToken: cancellationToken);
            await _campusEncounterBusinessRules.CampusEncounterShouldExistWhenSelected(campusEncounter);

            await _campusEncounterRepository.DeleteAsync(campusEncounter!);

            DeletedCampusEncounterResponse response = _mapper.Map<DeletedCampusEncounterResponse>(campusEncounter);
            return response;
        }
    }
}