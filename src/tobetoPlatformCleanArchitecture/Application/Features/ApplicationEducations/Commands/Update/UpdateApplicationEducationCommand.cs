using Application.Features.ApplicationEducations.Constants;
using Application.Features.ApplicationEducations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ApplicationEducations.Constants.ApplicationEducationsOperationClaims;

namespace Application.Features.ApplicationEducations.Commands.Update;

public class UpdateApplicationEducationCommand : IRequest<UpdatedApplicationEducationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, Write, ApplicationEducationsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetApplicationEducations";

    public class UpdateApplicationEducationCommandHandler : IRequestHandler<UpdateApplicationEducationCommand, UpdatedApplicationEducationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationEducationRepository _applicationEducationRepository;
        private readonly ApplicationEducationBusinessRules _applicationEducationBusinessRules;

        public UpdateApplicationEducationCommandHandler(IMapper mapper, IApplicationEducationRepository applicationEducationRepository,
                                         ApplicationEducationBusinessRules applicationEducationBusinessRules)
        {
            _mapper = mapper;
            _applicationEducationRepository = applicationEducationRepository;
            _applicationEducationBusinessRules = applicationEducationBusinessRules;
        }

        public async Task<UpdatedApplicationEducationResponse> Handle(UpdateApplicationEducationCommand request, CancellationToken cancellationToken)
        {
            ApplicationEducation? applicationEducation = await _applicationEducationRepository.GetAsync(predicate: ae => ae.Id == request.Id, cancellationToken: cancellationToken);
            await _applicationEducationBusinessRules.ApplicationEducationShouldExistWhenSelected(applicationEducation);
            applicationEducation = _mapper.Map(request, applicationEducation);

            await _applicationEducationRepository.UpdateAsync(applicationEducation!);

            UpdatedApplicationEducationResponse response = _mapper.Map<UpdatedApplicationEducationResponse>(applicationEducation);
            return response;
        }
    }
}