using Application.Features.Provinces.Constants;
using Application.Features.Provinces.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Provinces.Constants.ProvincesOperationClaims;

namespace Application.Features.Provinces.Commands.Create;

public class CreateProvinceCommand : IRequest<CreatedProvinceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, Write, ProvincesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProvinces";

    public class CreateProvinceCommandHandler : IRequestHandler<CreateProvinceCommand, CreatedProvinceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProvinceRepository _provinceRepository;
        private readonly ProvinceBusinessRules _provinceBusinessRules;

        public CreateProvinceCommandHandler(IMapper mapper, IProvinceRepository provinceRepository,
                                         ProvinceBusinessRules provinceBusinessRules)
        {
            _mapper = mapper;
            _provinceRepository = provinceRepository;
            _provinceBusinessRules = provinceBusinessRules;
        }

        public async Task<CreatedProvinceResponse> Handle(CreateProvinceCommand request, CancellationToken cancellationToken)
        {
            Province province = _mapper.Map<Province>(request);

            await _provinceRepository.AddAsync(province);

            CreatedProvinceResponse response = _mapper.Map<CreatedProvinceResponse>(province);
            return response;
        }
    }
}