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

namespace Application.Features.ProducerCompanies.Commands.Update;

public class UpdateProducerCompanyCommand : IRequest<UpdatedProducerCompanyResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, Write, ProducerCompaniesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProducerCompanies";

    public class UpdateProducerCompanyCommandHandler : IRequestHandler<UpdateProducerCompanyCommand, UpdatedProducerCompanyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProducerCompanyRepository _producerCompanyRepository;
        private readonly ProducerCompanyBusinessRules _producerCompanyBusinessRules;

        public UpdateProducerCompanyCommandHandler(IMapper mapper, IProducerCompanyRepository producerCompanyRepository,
                                         ProducerCompanyBusinessRules producerCompanyBusinessRules)
        {
            _mapper = mapper;
            _producerCompanyRepository = producerCompanyRepository;
            _producerCompanyBusinessRules = producerCompanyBusinessRules;
        }

        public async Task<UpdatedProducerCompanyResponse> Handle(UpdateProducerCompanyCommand request, CancellationToken cancellationToken)
        {
            ProducerCompany? producerCompany = await _producerCompanyRepository.GetAsync(predicate: pc => pc.Id == request.Id, cancellationToken: cancellationToken);
            await _producerCompanyBusinessRules.ProducerCompanyShouldExistWhenSelected(producerCompany);
            producerCompany = _mapper.Map(request, producerCompany);

            await _producerCompanyRepository.UpdateAsync(producerCompany!);

            UpdatedProducerCompanyResponse response = _mapper.Map<UpdatedProducerCompanyResponse>(producerCompany);
            return response;
        }
    }
}