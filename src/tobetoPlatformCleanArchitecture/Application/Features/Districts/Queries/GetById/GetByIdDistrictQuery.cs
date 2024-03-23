using Application.Features.Districts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Districts.Queries.GetById;

public class GetByIdDistrictQuery : IRequest<GetByIdDistrictResponse>
{
    public int Id { get; set; }

    public class GetByIdDistrictQueryHandler : IRequestHandler<GetByIdDistrictQuery, GetByIdDistrictResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDistrictRepository _districtRepository;
        private readonly DistrictBusinessRules _districtBusinessRules;

        public GetByIdDistrictQueryHandler(IMapper mapper, IDistrictRepository districtRepository, DistrictBusinessRules districtBusinessRules)
        {
            _mapper = mapper;
            _districtRepository = districtRepository;
            _districtBusinessRules = districtBusinessRules;
        }

        public async Task<GetByIdDistrictResponse> Handle(GetByIdDistrictQuery request, CancellationToken cancellationToken)
        {
            District? district = await _districtRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _districtBusinessRules.DistrictShouldExistWhenSelected(district);

            GetByIdDistrictResponse response = _mapper.Map<GetByIdDistrictResponse>(district);
            return response;
        }
    }
}