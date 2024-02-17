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

public class UpdateStudentCommand : IRequest<UpdatedStudentResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public UpdateStudentDto UpdateStudentDto { get; set; }


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
            Student? student = await _studentRepository.GetAsync(s => s.Id == request.UpdateStudentDto.Id, cancellationToken: cancellationToken);
            await _studentBusinessRules.StudentShouldExistWhenSelected(student);
          
            _mapper.Map(request.UpdateStudentDto, student);
            await _studentRepository.UpdateAsync(student!);

            User? user = await _userService.GetAsync(u => u.Id == student.UserId, cancellationToken: cancellationToken);
            await _userBusinessRules.UserShouldBeExistsWhenSelected(user);
           
            _mapper.Map(request.UpdateStudentDto, user);
            await _userService.UpdateAsync(user!);

            UpdatedStudentResponse response = _mapper.Map<UpdatedStudentResponse>(student);
            return response;
        }
    }
}