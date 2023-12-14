using Application.Features.UserSections.Constants;
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

namespace Application.Features.UserSections.Commands.Delete;

public class DeleteUserSectionCommand : IRequest<DeletedUserSectionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, UserSectionsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetUserSections";

    public class DeleteUserSectionCommandHandler : IRequestHandler<DeleteUserSectionCommand, DeletedUserSectionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserSectionRepository _userSectionRepository;
        private readonly UserSectionBusinessRules _userSectionBusinessRules;

        public DeleteUserSectionCommandHandler(IMapper mapper, IUserSectionRepository userSectionRepository,
                                         UserSectionBusinessRules userSectionBusinessRules)
        {
            _mapper = mapper;
            _userSectionRepository = userSectionRepository;
            _userSectionBusinessRules = userSectionBusinessRules;
        }

        public async Task<DeletedUserSectionResponse> Handle(DeleteUserSectionCommand request, CancellationToken cancellationToken)
        {
            UserSection? userSection = await _userSectionRepository.GetAsync(predicate: us => us.Id == request.Id, cancellationToken: cancellationToken);
            await _userSectionBusinessRules.UserSectionShouldExistWhenSelected(userSection);

            await _userSectionRepository.DeleteAsync(userSection!);

            DeletedUserSectionResponse response = _mapper.Map<DeletedUserSectionResponse>(userSection);
            return response;
        }
    }
}