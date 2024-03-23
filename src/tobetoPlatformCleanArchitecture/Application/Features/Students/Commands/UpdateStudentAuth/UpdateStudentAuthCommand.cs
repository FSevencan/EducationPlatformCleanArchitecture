using Application.Features.Students.Rules;
using Application.Features.Users.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Commands.UpdateStudentAuth;

public class UpdateStudentAuthCommand : IRequest<UpdateStudentAuthResponse>
{
    public UpdateStudentAuthDto UpdateStudentAuthDto { get; set; }
    
}

public class UpdateStudentAuthCommandHandler : IRequestHandler<UpdateStudentAuthCommand, UpdateStudentAuthResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;
    private readonly UserBusinessRules _userBusinessRules;
    private readonly StudentBusinessRules _studentBusinessRules;
    private readonly IMapper _mapper;

    public UpdateStudentAuthCommandHandler(
        IUserRepository userRepository,
        IAuthService authService,
        IMapper mapper,
        UserBusinessRules userBusinessRules,
        StudentBusinessRules studentBusinessRules)

    {
        _userRepository = userRepository;
        _authService = authService;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
        _studentBusinessRules = studentBusinessRules;
    }

    public async Task<UpdateStudentAuthResponse> Handle(UpdateStudentAuthCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetAsync(u => u.Id == request.UpdateStudentAuthDto.UserId);

        _userBusinessRules.UserShouldBeExistsWhenSelected(user);
        _studentBusinessRules.CheckIfPasswordsMatch(request.UpdateStudentAuthDto.CurrentPassword, user.PasswordHash, user.PasswordSalt);
        _studentBusinessRules.CheckIfNewPasswordMatches(request.UpdateStudentAuthDto.NewPassword, request.UpdateStudentAuthDto.ConfirmNewPassword);

        if (!string.IsNullOrWhiteSpace(request.UpdateStudentAuthDto.NewPassword))
        {
            HashingHelper.CreatePasswordHash(request.UpdateStudentAuthDto.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
        }

        await _userRepository.UpdateAsync(user);

        // Access token yeniden oluştur
        var accessToken = await _authService.CreateAccessToken(user);

        var response = _mapper.Map<UpdateStudentAuthResponse>(user);

        return response;
    }
}