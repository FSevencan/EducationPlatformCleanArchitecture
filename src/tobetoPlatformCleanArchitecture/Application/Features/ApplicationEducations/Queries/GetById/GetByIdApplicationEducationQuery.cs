using Application.Features.ApplicationEducations.Constants;
using Application.Features.ApplicationEducations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ApplicationEducations.Constants.ApplicationEducationsOperationClaims;

namespace Application.Features.ApplicationEducations.Queries.GetById;

public class GetByIdApplicationEducationQuery : IRequest<GetByIdApplicationEducationResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdApplicationEducationQueryHandler : IRequestHandler<GetByIdApplicationEducationQuery, GetByIdApplicationEducationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationEducationRepository _applicationEducationRepository;
        private readonly ApplicationEducationBusinessRules _applicationEducationBusinessRules;

        public GetByIdApplicationEducationQueryHandler(IMapper mapper, IApplicationEducationRepository applicationEducationRepository, ApplicationEducationBusinessRules applicationEducationBusinessRules)
        {
            _mapper = mapper;
            _applicationEducationRepository = applicationEducationRepository;
            _applicationEducationBusinessRules = applicationEducationBusinessRules;
        }

        public async Task<GetByIdApplicationEducationResponse> Handle(GetByIdApplicationEducationQuery request, CancellationToken cancellationToken)
        {
            ApplicationEducation? applicationEducation = await _applicationEducationRepository.GetAsync(predicate: ae => ae.Id == request.Id, cancellationToken: cancellationToken);
            await _applicationEducationBusinessRules.ApplicationEducationShouldExistWhenSelected(applicationEducation);

            GetByIdApplicationEducationResponse response = _mapper.Map<GetByIdApplicationEducationResponse>(applicationEducation);
            return response;
        }
    }
}