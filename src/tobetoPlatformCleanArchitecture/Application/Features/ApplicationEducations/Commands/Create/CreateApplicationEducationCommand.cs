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

namespace Application.Features.ApplicationEducations.Commands.Create;

public class CreateApplicationEducationCommand : IRequest<CreatedApplicationEducationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, Write, ApplicationEducationsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetApplicationEducations";

    public class CreateApplicationEducationCommandHandler : IRequestHandler<CreateApplicationEducationCommand, CreatedApplicationEducationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationEducationRepository _applicationEducationRepository;
        private readonly ApplicationEducationBusinessRules _applicationEducationBusinessRules;

        public CreateApplicationEducationCommandHandler(IMapper mapper, IApplicationEducationRepository applicationEducationRepository,
                                         ApplicationEducationBusinessRules applicationEducationBusinessRules)
        {
            _mapper = mapper;
            _applicationEducationRepository = applicationEducationRepository;
            _applicationEducationBusinessRules = applicationEducationBusinessRules;
        }

        public async Task<CreatedApplicationEducationResponse> Handle(CreateApplicationEducationCommand request, CancellationToken cancellationToken)
        {
            ApplicationEducation applicationEducation = _mapper.Map<ApplicationEducation>(request);

            await _applicationEducationRepository.AddAsync(applicationEducation);

            CreatedApplicationEducationResponse response = _mapper.Map<CreatedApplicationEducationResponse>(applicationEducation);
            return response;
        }
    }
}