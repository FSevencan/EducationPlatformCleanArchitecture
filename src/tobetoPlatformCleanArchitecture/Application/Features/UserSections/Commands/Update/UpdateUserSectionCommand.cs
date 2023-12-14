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

namespace Application.Features.UserSections.Commands.Update;

public class UpdateUserSectionCommand : IRequest<UpdatedUserSectionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid SectionId { get; set; }
    public int UserId { get; set; }

    public string[] Roles => new[] { Admin, Write, UserSectionsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetUserSections";

    public class UpdateUserSectionCommandHandler : IRequestHandler<UpdateUserSectionCommand, UpdatedUserSectionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserSectionRepository _userSectionRepository;
        private readonly UserSectionBusinessRules _userSectionBusinessRules;

        public UpdateUserSectionCommandHandler(IMapper mapper, IUserSectionRepository userSectionRepository,
                                         UserSectionBusinessRules userSectionBusinessRules)
        {
            _mapper = mapper;
            _userSectionRepository = userSectionRepository;
            _userSectionBusinessRules = userSectionBusinessRules;
        }

        public async Task<UpdatedUserSectionResponse> Handle(UpdateUserSectionCommand request, CancellationToken cancellationToken)
        {
            UserSection? userSection = await _userSectionRepository.GetAsync(predicate: us => us.Id == request.Id, cancellationToken: cancellationToken);
            await _userSectionBusinessRules.UserSectionShouldExistWhenSelected(userSection);
            userSection = _mapper.Map(request, userSection);

            await _userSectionRepository.UpdateAsync(userSection!);

            UpdatedUserSectionResponse response = _mapper.Map<UpdatedUserSectionResponse>(userSection);
            return response;
        }
    }
}