using Application.Features.AppUsers.Constants;
using Application.Features.AppUsers.Constants;
using Application.Features.AppUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AppUsers.Constants.AppUsersOperationClaims;

namespace Application.Features.AppUsers.Commands.Delete;

public class DeleteAppUserCommand : IRequest<DeletedAppUserResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AppUsersOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAppUsers";

    public class DeleteAppUserCommandHandler : IRequestHandler<DeleteAppUserCommand, DeletedAppUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAppUserRepository _appUserRepository;
        private readonly AppUserBusinessRules _appUserBusinessRules;

        public DeleteAppUserCommandHandler(IMapper mapper, IAppUserRepository appUserRepository,
                                         AppUserBusinessRules appUserBusinessRules)
        {
            _mapper = mapper;
            _appUserRepository = appUserRepository;
            _appUserBusinessRules = appUserBusinessRules;
        }

        public async Task<DeletedAppUserResponse> Handle(DeleteAppUserCommand request, CancellationToken cancellationToken)
        {
            AppUser? appUser = await _appUserRepository.GetAsync(predicate: au => au.Id == request.Id, cancellationToken: cancellationToken);
            await _appUserBusinessRules.AppUserShouldExistWhenSelected(appUser);

            await _appUserRepository.DeleteAsync(appUser!);

            DeletedAppUserResponse response = _mapper.Map<DeletedAppUserResponse>(appUser);
            return response;
        }
    }
}