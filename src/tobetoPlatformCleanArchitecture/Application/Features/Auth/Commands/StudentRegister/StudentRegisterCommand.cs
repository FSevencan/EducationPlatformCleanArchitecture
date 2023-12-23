using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Application.Services.Students;
using Core.Application.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;

namespace Application.Features.Auth.Commands.StudentRegister;
public class StudentRegisterCommand : IRequest<StudentRegisteredResponse>
{
    public StudentForRegisterDto StudentForRegisterDto { get; set; }
    public string IpAddress { get; set; }

    public StudentRegisterCommand()
    {
        StudentForRegisterDto = null!;
        IpAddress = string.Empty;
    }

    public StudentRegisterCommand(StudentForRegisterDto studentForRegisterDto, string ipAddress)
    {
        StudentForRegisterDto = studentForRegisterDto;
        IpAddress = ipAddress;
    }



    public class StudentRegisterCommandHandler : IRequestHandler<StudentRegisterCommand, StudentRegisteredResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IStudentsService _studentsService;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;

        public StudentRegisterCommandHandler(IUserRepository userRepository, IStudentsService studentsService, IAuthService authService, AuthBusinessRules authBusinessRules)
        {
            _userRepository = userRepository;
            _studentsService = studentsService;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<StudentRegisteredResponse> Handle(StudentRegisterCommand request, CancellationToken cancellationToken)
        {

            await _authBusinessRules.StudentEmailShouldBeNotExists(request.StudentForRegisterDto.Email);

            HashingHelper.CreatePasswordHash(
                request.StudentForRegisterDto.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            User newUser =
                new()
                {
                    Email = request.StudentForRegisterDto.Email,
                    FirstName = request.StudentForRegisterDto.FirstName,
                    LastName = request.StudentForRegisterDto.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                };

            User createdUser = await _userRepository.AddAsync(newUser);

            Student newStudent =
               new()
               {
                   UserId = createdUser.Id
               };

            var createdStudent = await _studentsService.AddAsync(newStudent);

            AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

            Core.Security.Entities.RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
            Core.Security.Entities.RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

            StudentRegisteredResponse studentRegisteredResponse = new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
            return studentRegisteredResponse;
        }

    }
}
