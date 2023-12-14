using Application.Features.ApplicationEducations.Constants;
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

namespace Application.Features.ApplicationEducations.Commands.Delete;

public class DeleteApplicationEducationCommand : IRequest<DeletedApplicationEducationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ApplicationEducationsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetApplicationEducations";

    public class DeleteApplicationEducationCommandHandler : IRequestHandler<DeleteApplicationEducationCommand, DeletedApplicationEducationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationEducationRepository _applicationEducationRepository;
        private readonly ApplicationEducationBusinessRules _applicationEducationBusinessRules;

        public DeleteApplicationEducationCommandHandler(IMapper mapper, IApplicationEducationRepository applicationEducationRepository,
                                         ApplicationEducationBusinessRules applicationEducationBusinessRules)
        {
            _mapper = mapper;
            _applicationEducationRepository = applicationEducationRepository;
            _applicationEducationBusinessRules = applicationEducationBusinessRules;
        }

        public async Task<DeletedApplicationEducationResponse> Handle(DeleteApplicationEducationCommand request, CancellationToken cancellationToken)
        {
            ApplicationEducation? applicationEducation = await _applicationEducationRepository.GetAsync(predicate: ae => ae.Id == request.Id, cancellationToken: cancellationToken);
            await _applicationEducationBusinessRules.ApplicationEducationShouldExistWhenSelected(applicationEducation);

            await _applicationEducationRepository.DeleteAsync(applicationEducation!);

            DeletedApplicationEducationResponse response = _mapper.Map<DeletedApplicationEducationResponse>(applicationEducation);
            return response;
        }
    }
}