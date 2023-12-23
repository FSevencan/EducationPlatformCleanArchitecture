using Application.Features.Students.Constants;
using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Students.Constants.StudentsOperationClaims;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Services.UsersService;
using Application.Features.Users.Rules;
using Core.Security.Hashing;

namespace Application.Features.Students.Commands.Update;

public class UpdateStudentCommand : IRequest<UpdatedStudentResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public UpdateStudentDto StudentDto { get; set; }
    

    public string[] Roles => new[] { Admin, Write, StudentsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStudents";

    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, UpdatedStudentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly IUserService _userService;
        private readonly StudentBusinessRules _studentBusinessRules;
        private readonly UserBusinessRules _userBusinessRules;

        public UpdateStudentCommandHandler(IMapper mapper, IUserService userService, IStudentRepository studentRepository,
                                         StudentBusinessRules studentBusinessRules, UserBusinessRules userBusinessRules)
        {
            _mapper = mapper;
            _userService = userService;
            _studentRepository = studentRepository;
            _studentBusinessRules = studentBusinessRules;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<UpdatedStudentResponse> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            Student? student = await _studentRepository.GetAsync(predicate: s => s.Id == request.StudentDto.Id, cancellationToken: cancellationToken);
            await _studentBusinessRules.StudentShouldExistWhenSelected(student);
            student = _mapper.Map(request.StudentDto, student);
            await _studentRepository.UpdateAsync(student!);


            User? user = await _userService.GetAsync(predicate: u=>u.Id==request.StudentDto.UserId, cancellationToken: cancellationToken);
            await _userBusinessRules.UserShouldBeExistsWhenSelected(user);
            user.FirstName = request.StudentDto.FirstName;
            user.LastName = request.StudentDto.LastName;
            user.Email = request.StudentDto.Email;
            if(request.StudentDto.Password != null)
            {
                HashingHelper.CreatePasswordHash(
                request.StudentDto.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
                );
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            };
            await _userService.UpdateAsync(user!);

            UpdatedStudentResponse response = _mapper.Map<UpdatedStudentResponse>(student);
            return response;
        }
    }
}