using Application.Features.Auth.Rules;
using Application.Services.Repositories;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Auth.Commands.VerifyEmailAuthenticator;

using Application.Features.Lessons.Queries.GetById;
using AutoMapper;
using Domain.Entities;
public class VerifyUserIDActivationKeyCommand : IRequest<UserIDIsVerifiedResponse>
{
    public int UserId { get; set; }


    public class VerifyUserIDActivationKeyCommandHandler : IRequestHandler<VerifyUserIDActivationKeyCommand, UserIDIsVerifiedResponse>
    {
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IMapper _mapper;

        private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;

        public VerifyUserIDActivationKeyCommandHandler(
            IEmailAuthenticatorRepository emailAuthenticatorRepository,
            AuthBusinessRules authBusinessRules, IMapper mapper
        )
        {
            _emailAuthenticatorRepository = emailAuthenticatorRepository;
            _authBusinessRules = authBusinessRules;
            _mapper = mapper;

        }

        public async Task<UserIDIsVerifiedResponse> Handle(VerifyUserIDActivationKeyCommand request, CancellationToken cancellationToken)
        {
            EmailAuthenticator? emailAuthenticator = await _emailAuthenticatorRepository.GetAsync(
                predicate: e => e.UserId == request.UserId,
                cancellationToken: cancellationToken
            );

            await _authBusinessRules.EmailAuthenticatorShouldBeExists(emailAuthenticator);
            await _authBusinessRules.EmailAuthenticatorActivationKeyShouldBeExists(emailAuthenticator!);


            UserIDIsVerifiedResponse response = _mapper.Map<UserIDIsVerifiedResponse>(emailAuthenticator);
            
            
            return response;
            
        }
    }
}


