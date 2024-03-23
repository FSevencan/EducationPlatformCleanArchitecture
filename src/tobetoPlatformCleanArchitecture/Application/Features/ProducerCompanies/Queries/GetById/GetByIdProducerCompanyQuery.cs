using Application.Features.ProducerCompanies.Constants;
using Application.Features.ProducerCompanies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ProducerCompanies.Constants.ProducerCompaniesOperationClaims;

namespace Application.Features.ProducerCompanies.Queries.GetById;

public class GetByIdProducerCompanyQuery : IRequest<GetByIdProducerCompanyResponse>
{
    public Guid Id { get; set; }


    public class GetByIdProducerCompanyQueryHandler : IRequestHandler<GetByIdProducerCompanyQuery, GetByIdProducerCompanyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProducerCompanyRepository _producerCompanyRepository;
        private readonly ProducerCompanyBusinessRules _producerCompanyBusinessRules;

        public GetByIdProducerCompanyQueryHandler(IMapper mapper, IProducerCompanyRepository producerCompanyRepository, ProducerCompanyBusinessRules producerCompanyBusinessRules)
        {
            _mapper = mapper;
            _producerCompanyRepository = producerCompanyRepository;
            _producerCompanyBusinessRules = producerCompanyBusinessRules;
        }

        public async Task<GetByIdProducerCompanyResponse> Handle(GetByIdProducerCompanyQuery request, CancellationToken cancellationToken)
        {
            ProducerCompany? producerCompany = await _producerCompanyRepository.GetAsync(predicate: pc => pc.Id == request.Id, cancellationToken: cancellationToken);
            await _producerCompanyBusinessRules.ProducerCompanyShouldExistWhenSelected(producerCompany);

            GetByIdProducerCompanyResponse response = _mapper.Map<GetByIdProducerCompanyResponse>(producerCompany);
            return response;
        }
    }
}