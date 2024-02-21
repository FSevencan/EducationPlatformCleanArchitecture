using Application.Features.Provinces.Constants;
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

namespace Application.Features.Provinces.Commands.Delete;

public class DeleteProvinceCommand : IRequest<DeletedProvinceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ProvincesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProvinces";

    public class DeleteProvinceCommandHandler : IRequestHandler<DeleteProvinceCommand, DeletedProvinceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProvinceRepository _provinceRepository;
        private readonly ProvinceBusinessRules _provinceBusinessRules;

        public DeleteProvinceCommandHandler(IMapper mapper, IProvinceRepository provinceRepository,
                                         ProvinceBusinessRules provinceBusinessRules)
        {
            _mapper = mapper;
            _provinceRepository = provinceRepository;
            _provinceBusinessRules = provinceBusinessRules;
        }

        public async Task<DeletedProvinceResponse> Handle(DeleteProvinceCommand request, CancellationToken cancellationToken)
        {
            Province? province = await _provinceRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _provinceBusinessRules.ProvinceShouldExistWhenSelected(province);

            await _provinceRepository.DeleteAsync(province!);

            DeletedProvinceResponse response = _mapper.Map<DeletedProvinceResponse>(province);
            return response;
        }
    }
}