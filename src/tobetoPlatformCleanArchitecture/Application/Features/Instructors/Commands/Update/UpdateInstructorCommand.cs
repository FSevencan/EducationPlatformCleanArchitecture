using Application.Features.Instructors.Constants;
using Application.Features.Instructors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Instructors.Constants.InstructorsOperationClaims;
using Core.Security.Entities;
using Application.Features.Users.Rules;
using Application.Services.UsersService;
using Core.Security.Hashing;

namespace Application.Features.Instructors.Commands.Update;

public class UpdateInstructorCommand : IRequest<UpdatedInstructorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public UpdateInstructorDto InstructorDto { get; set; }
    
   

    public string[] Roles => new[] { Admin, Write, InstructorsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetInstructors";

    public class UpdateInstructorCommandHandler : IRequestHandler<UpdateInstructorCommand, UpdatedInstructorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IUserService _userService;
        private readonly InstructorBusinessRules _instructorBusinessRules;
        private readonly UserBusinessRules _userBusinessRules;

        public UpdateInstructorCommandHandler(IMapper mapper, IInstructorRepository instructorRepository,
                                         InstructorBusinessRules instructorBusinessRules, IUserService userService, UserBusinessRules userBusinessRules)
        {
            _mapper = mapper;
            _instructorRepository = instructorRepository;
            _instructorBusinessRules = instructorBusinessRules;
            _userService = userService;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<UpdatedInstructorResponse> Handle(UpdateInstructorCommand request, CancellationToken cancellationToken)
        {
            Instructor? instructor = await _instructorRepository.GetAsync(predicate: i => i.Id == request.InstructorDto.Id, cancellationToken: cancellationToken);
            await _instructorBusinessRules.InstructorShouldExistWhenSelected(instructor);
            instructor = _mapper.Map(request.InstructorDto, instructor);
            await _instructorRepository.UpdateAsync(instructor!);

            User? user = await _userService.GetAsync(predicate: u => u.Id == request.InstructorDto.UserId, cancellationToken: cancellationToken);
            await _userBusinessRules.UserShouldBeExistsWhenSelected(user);
            user.FirstName = request.InstructorDto.FirstName;
            user.LastName = request.InstructorDto.LastName;
            user.Email = request.InstructorDto.Email;
            if (request.InstructorDto.Password != null)
            {
                HashingHelper.CreatePasswordHash(
                request.InstructorDto.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
                );
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            };
            await _userService.UpdateAsync(user!);

            UpdatedInstructorResponse response = _mapper.Map<UpdatedInstructorResponse>(instructor);
            return response;
        }
    }
}