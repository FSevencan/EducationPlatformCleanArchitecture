using Application.Features.UserSections.Constants;
using Application.Features.UserSections.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.UserSections.Constants.UserSectionsOperationClaims;

namespace Application.Features.UserSections.Commands.Create;

public class CreateUserSectionCommand : IRequest<CreatedUserSectionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid SectionId { get; set; }
    public int UserId { get; set; }

    public string[] Roles => new[] { Admin, Write, UserSectionsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetUserSections";

    public class CreateUserSectionCommandHandler : IRequestHandler<CreateUserSectionCommand, CreatedUserSectionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserSectionRepository _userSectionRepository;
        private readonly UserSectionBusinessRules _userSectionBusinessRules;

        public CreateUserSectionCommandHandler(IMapper mapper, IUserSectionRepository userSectionRepository,
                                         UserSectionBusinessRules userSectionBusinessRules)
        {
            _mapper = mapper;
            _userSectionRepository = userSectionRepository;
            _userSectionBusinessRules = userSectionBusinessRules;
        }

        public async Task<CreatedUserSectionResponse> Handle(CreateUserSectionCommand request, CancellationToken cancellationToken)
        {
            UserSection userSection = _mapper.Map<UserSection>(request);

            await _userSectionRepository.AddAsync(userSection);

            CreatedUserSectionResponse response = _mapper.Map<CreatedUserSectionResponse>(userSection);
            return response;
        }
    }
}