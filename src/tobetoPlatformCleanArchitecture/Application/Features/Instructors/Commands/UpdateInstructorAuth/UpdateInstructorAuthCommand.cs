using Application.Features.Instructors.Rules;
using Application.Features.Users.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Instructors.Commands.UpdateInstructorAuth;
public class UpdateInstructorAuthCommand : IRequest<UpdateInstructorAuthResponse>
{
    public UpdateInstructorAuthDto UpdateInstructorAuthDto { get; set; }
}


public class UpdateInstructorAuthCommandHandler : IRequestHandler<UpdateInstructorAuthCommand, UpdateInstructorAuthResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;
    private readonly UserBusinessRules _userBusinessRules;
    private readonly InstructorBusinessRules _instructorBusinessRules ;
    private readonly IMapper _mapper;

    public UpdateInstructorAuthCommandHandler(
        IUserRepository userRepository,
        IAuthService authService,
        IMapper mapper,
        UserBusinessRules userBusinessRules,
        InstructorBusinessRules instructorBusinessRules)

    {
        _userRepository = userRepository;
        _authService = authService;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
        _instructorBusinessRules = instructorBusinessRules;
    }

    public async Task<UpdateInstructorAuthResponse> Handle(UpdateInstructorAuthCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetAsync(u => u.Id == request.UpdateInstructorAuthDto.UserId);

        _userBusinessRules.UserShouldBeExistsWhenSelected(user);
        _instructorBusinessRules.CheckIfPasswordsMatch(request.UpdateInstructorAuthDto.CurrentPassword, user.PasswordHash, user.PasswordSalt);
        _instructorBusinessRules.CheckIfNewPasswordMatches(request.UpdateInstructorAuthDto.NewPassword, request.UpdateInstructorAuthDto.ConfirmNewPassword);

        if (!string.IsNullOrWhiteSpace(request.UpdateInstructorAuthDto.NewPassword))
        {
            HashingHelper.CreatePasswordHash(request.UpdateInstructorAuthDto.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
        }

        await _userRepository.UpdateAsync(user);

        // Access token yeniden oluştur
        var accessToken = await _authService.CreateAccessToken(user);

        var response = _mapper.Map<UpdateInstructorAuthResponse>(user);

        return response;
    }
}
