using Application.Features.Districts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Districts.Commands.Update;

public class UpdateDistrictCommand : IRequest<UpdatedDistrictResponse>
{
    public int Id { get; set; }
    public int ProvinceId { get; set; }
    public string Name { get; set; }
    public Province Province { get; set; }

    public class UpdateDistrictCommandHandler : IRequestHandler<UpdateDistrictCommand, UpdatedDistrictResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDistrictRepository _districtRepository;
        private readonly DistrictBusinessRules _districtBusinessRules;

        public UpdateDistrictCommandHandler(IMapper mapper, IDistrictRepository districtRepository,
                                         DistrictBusinessRules districtBusinessRules)
        {
            _mapper = mapper;
            _districtRepository = districtRepository;
            _districtBusinessRules = districtBusinessRules;
        }

        public async Task<UpdatedDistrictResponse> Handle(UpdateDistrictCommand request, CancellationToken cancellationToken)
        {
            District? district = await _districtRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _districtBusinessRules.DistrictShouldExistWhenSelected(district);
            district = _mapper.Map(request, district);

            await _districtRepository.UpdateAsync(district!);

            UpdatedDistrictResponse response = _mapper.Map<UpdatedDistrictResponse>(district);
            return response;
        }
    }
}