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
using Core.Security.Enums;
using Application.Features.Users.Rules;
using Core.Security.Entities;
using Core.Security.Hashing;

namespace Application.Features.AppUsers.Commands.Create;

public class CreateAppUserCommand : IRequest<CreatedAppUserResponse>,  ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }



    public string[] Roles => new[] { Admin, Write, AppUsersOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAppUsers";

    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand, CreatedAppUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAppUserRepository _appUserRepository;
        private readonly AppUserBusinessRules _appUserBusinessRules;

        public CreateAppUserCommandHandler(IMapper mapper, IAppUserRepository appUserRepository,
                                         AppUserBusinessRules appUserBusinessRules)
        {
            _mapper = mapper;
            _appUserRepository = appUserRepository;
            _appUserBusinessRules = appUserBusinessRules;
        }

        public async Task<CreatedAppUserResponse> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            await _appUserBusinessRules.AppUserEmailShouldNotExistsWhenInsert(request.Email);
            AppUser appUser = _mapper.Map<AppUser>(request);

            HashingHelper.CreatePasswordHash(
              request.Password,
              passwordHash: out byte[] passwordHash,
              passwordSalt: out byte[] passwordSalt
                );
            appUser.PasswordHash = passwordHash;
            appUser.PasswordSalt = passwordSalt;

            AppUser createdUser = await _appUserRepository.AddAsync(appUser);

            CreatedAppUserResponse response = _mapper.Map<CreatedAppUserResponse>(createdUser);
            return response;
        }
    }
}