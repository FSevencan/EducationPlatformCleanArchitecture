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

namespace Application.Features.AppUsers.Commands.Update;

public class UpdateAppUserCommand : IRequest<UpdatedAppUserResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string About { get; set; }
    public string? GithubUrl { get; set; }
    public string? LinkedinUrl { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }

    public string[] Roles => new[] { Admin, Write, AppUsersOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAppUsers";

    public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommand, UpdatedAppUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAppUserRepository _appUserRepository;
        private readonly AppUserBusinessRules _appUserBusinessRules;

        public UpdateAppUserCommandHandler(IMapper mapper, IAppUserRepository appUserRepository,
                                         AppUserBusinessRules appUserBusinessRules)
        {
            _mapper = mapper;
            _appUserRepository = appUserRepository;
            _appUserBusinessRules = appUserBusinessRules;
        }

        public async Task<UpdatedAppUserResponse> Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            AppUser? appUser = await _appUserRepository.GetAsync(predicate: au => au.Id == request.Id, cancellationToken: cancellationToken);
            await _appUserBusinessRules.AppUserShouldExistWhenSelected(appUser);
            appUser = _mapper.Map(request, appUser);

            await _appUserRepository.UpdateAsync(appUser!);

            UpdatedAppUserResponse response = _mapper.Map<UpdatedAppUserResponse>(appUser);
            return response;
        }
    }
}