using Application.Features.AppUsers.Constants;
using Application.Features.AppUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AppUsers.Constants.AppUsersOperationClaims;

namespace Application.Features.AppUsers.Queries.GetById;

public class GetByIdAppUserQuery : IRequest<GetByIdAppUserResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAppUserQueryHandler : IRequestHandler<GetByIdAppUserQuery, GetByIdAppUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAppUserRepository _appUserRepository;
        private readonly AppUserBusinessRules _appUserBusinessRules;

        public GetByIdAppUserQueryHandler(IMapper mapper, IAppUserRepository appUserRepository, AppUserBusinessRules appUserBusinessRules)
        {
            _mapper = mapper;
            _appUserRepository = appUserRepository;
            _appUserBusinessRules = appUserBusinessRules;
        }

        public async Task<GetByIdAppUserResponse> Handle(GetByIdAppUserQuery request, CancellationToken cancellationToken)
        {
            AppUser? appUser = await _appUserRepository.GetAsync(predicate: au => au.Id == request.Id, cancellationToken: cancellationToken);
            await _appUserBusinessRules.AppUserShouldExistWhenSelected(appUser);

            GetByIdAppUserResponse response = _mapper.Map<GetByIdAppUserResponse>(appUser);
            return response;
        }
    }
}