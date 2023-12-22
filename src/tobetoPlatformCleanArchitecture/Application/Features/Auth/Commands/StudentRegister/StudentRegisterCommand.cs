using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.Application.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.StudentRegister;
public class StudentRegisterCommand : IRequest<StudentRegisteredResponse>
{
    public UserForRegisterDto UserForRegisterDto { get; set; }
    public string IpAddress { get; set; }

    public StudentRegisterCommand()
    {
        UserForRegisterDto = null!;
        IpAddress = string.Empty;
    }

    public StudentRegisterCommand(UserForRegisterDto userForRegisterDto, string ipAddress)
    {
        UserForRegisterDto = userForRegisterDto;
        IpAddress = ipAddress;
    }



    public class StudentRegisterCommandHandler : IRequestHandler<StudentRegisterCommand, StudentRegisteredResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;

        public StudentRegisterCommandHandler(IUserRepository userRepository, IStudentRepository studentRepository, IAuthService authService, AuthBusinessRules authBusinessRules)
        {
            _userRepository = userRepository;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<StudentRegisteredResponse> Handle(StudentRegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);

            HashingHelper.CreatePasswordHash(
                request.UserForRegisterDto.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            User newUser =
                new()
                {
                    Email = request.UserForRegisterDto.Email,
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                };

            User createdUser = await _userRepository.AddAsync(newUser);

            Student newStudent =
               new()
               {
                   UserId = createdUser.Id, 
                   Email = request.UserForRegisterDto.Email,
                   FirstName = request.UserForRegisterDto.FirstName,
                   LastName = request.UserForRegisterDto.LastName,
               };


            var createdStudent = await _studentRepository.AddAsync(newStudent);

            AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

            Core.Security.Entities.RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
            Core.Security.Entities.RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

            StudentRegisteredResponse studentRegisteredResponse = new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
            return studentRegisteredResponse;
        }

    }
}
