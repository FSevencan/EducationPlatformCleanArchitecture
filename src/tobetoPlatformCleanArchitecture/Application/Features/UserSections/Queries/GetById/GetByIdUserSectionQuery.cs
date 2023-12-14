using Application.Features.UserSections.Constants;
using Application.Features.UserSections.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.UserSections.Constants.UserSectionsOperationClaims;

namespace Application.Features.UserSections.Queries.GetById;

public class GetByIdUserSectionQuery : IRequest<GetByIdUserSectionResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdUserSectionQueryHandler : IRequestHandler<GetByIdUserSectionQuery, GetByIdUserSectionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserSectionRepository _userSectionRepository;
        private readonly UserSectionBusinessRules _userSectionBusinessRules;

        public GetByIdUserSectionQueryHandler(IMapper mapper, IUserSectionRepository userSectionRepository, UserSectionBusinessRules userSectionBusinessRules)
        {
            _mapper = mapper;
            _userSectionRepository = userSectionRepository;
            _userSectionBusinessRules = userSectionBusinessRules;
        }

        public async Task<GetByIdUserSectionResponse> Handle(GetByIdUserSectionQuery request, CancellationToken cancellationToken)
        {
            UserSection? userSection = await _userSectionRepository.GetAsync(predicate: us => us.Id == request.Id, cancellationToken: cancellationToken);
            await _userSectionBusinessRules.UserSectionShouldExistWhenSelected(userSection);

            GetByIdUserSectionResponse response = _mapper.Map<GetByIdUserSectionResponse>(userSection);
            return response;
        }
    }
}