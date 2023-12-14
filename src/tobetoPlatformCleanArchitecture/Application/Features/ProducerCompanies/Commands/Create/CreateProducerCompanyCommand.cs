using Application.Features.ProducerCompanies.Constants;
using Application.Features.ProducerCompanies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ProducerCompanies.Constants.ProducerCompaniesOperationClaims;

namespace Application.Features.ProducerCompanies.Commands.Create;

public class CreateProducerCompanyCommand : IRequest<CreatedProducerCompanyResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, Write, ProducerCompaniesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProducerCompanies";

    public class CreateProducerCompanyCommandHandler : IRequestHandler<CreateProducerCompanyCommand, CreatedProducerCompanyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProducerCompanyRepository _producerCompanyRepository;
        private readonly ProducerCompanyBusinessRules _producerCompanyBusinessRules;

        public CreateProducerCompanyCommandHandler(IMapper mapper, IProducerCompanyRepository producerCompanyRepository,
                                         ProducerCompanyBusinessRules producerCompanyBusinessRules)
        {
            _mapper = mapper;
            _producerCompanyRepository = producerCompanyRepository;
            _producerCompanyBusinessRules = producerCompanyBusinessRules;
        }

        public async Task<CreatedProducerCompanyResponse> Handle(CreateProducerCompanyCommand request, CancellationToken cancellationToken)
        {
            ProducerCompany producerCompany = _mapper.Map<ProducerCompany>(request);

            await _producerCompanyRepository.AddAsync(producerCompany);

            CreatedProducerCompanyResponse response = _mapper.Map<CreatedProducerCompanyResponse>(producerCompany);
            return response;
        }
    }
}