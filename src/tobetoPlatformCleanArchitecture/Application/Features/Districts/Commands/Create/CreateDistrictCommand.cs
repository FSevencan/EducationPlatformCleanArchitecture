using Application.Features.Districts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Districts.Commands.Create;

public class CreateDistrictCommand : IRequest<CreatedDistrictResponse>
{
    public int ProvinceId { get; set; }
    public string Name { get; set; }
    public Province Province { get; set; }

    public class CreateDistrictCommandHandler : IRequestHandler<CreateDistrictCommand, CreatedDistrictResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDistrictRepository _districtRepository;
        private readonly DistrictBusinessRules _districtBusinessRules;

        public CreateDistrictCommandHandler(IMapper mapper, IDistrictRepository districtRepository,
                                         DistrictBusinessRules districtBusinessRules)
        {
            _mapper = mapper;
            _districtRepository = districtRepository;
            _districtBusinessRules = districtBusinessRules;
        }

        public async Task<CreatedDistrictResponse> Handle(CreateDistrictCommand request, CancellationToken cancellationToken)
        {
            District district = _mapper.Map<District>(request);

            await _districtRepository.AddAsync(district);

            CreatedDistrictResponse response = _mapper.Map<CreatedDistrictResponse>(district);
            return response;
        }
    }
}