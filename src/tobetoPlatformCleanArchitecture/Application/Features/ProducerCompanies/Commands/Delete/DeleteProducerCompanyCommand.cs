using Application.Features.ProducerCompanies.Constants;
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

namespace Application.Features.ProducerCompanies.Commands.Delete;

public class DeleteProducerCompanyCommand : IRequest<DeletedProducerCompanyResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ProducerCompaniesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProducerCompanies";

    public class DeleteProducerCompanyCommandHandler : IRequestHandler<DeleteProducerCompanyCommand, DeletedProducerCompanyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProducerCompanyRepository _producerCompanyRepository;
        private readonly ProducerCompanyBusinessRules _producerCompanyBusinessRules;

        public DeleteProducerCompanyCommandHandler(IMapper mapper, IProducerCompanyRepository producerCompanyRepository,
                                         ProducerCompanyBusinessRules producerCompanyBusinessRules)
        {
            _mapper = mapper;
            _producerCompanyRepository = producerCompanyRepository;
            _producerCompanyBusinessRules = producerCompanyBusinessRules;
        }

        public async Task<DeletedProducerCompanyResponse> Handle(DeleteProducerCompanyCommand request, CancellationToken cancellationToken)
        {
            ProducerCompany? producerCompany = await _producerCompanyRepository.GetAsync(predicate: pc => pc.Id == request.Id, cancellationToken: cancellationToken);
            await _producerCompanyBusinessRules.ProducerCompanyShouldExistWhenSelected(producerCompany);

            await _producerCompanyRepository.DeleteAsync(producerCompany!);

            DeletedProducerCompanyResponse response = _mapper.Map<DeletedProducerCompanyResponse>(producerCompany);
            return response;
        }
    }
}