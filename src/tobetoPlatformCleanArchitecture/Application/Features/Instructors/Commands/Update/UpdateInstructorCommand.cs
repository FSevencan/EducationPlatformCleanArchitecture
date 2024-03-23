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

public class UpdateInstructorCommand : IRequest<UpdatedInstructorResponse>/*, ISecuredRequest*/, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public UpdateInstructorDto UpdateInstructorDto { get; set; }
    
   

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
            Instructor? instructor = await _instructorRepository.GetAsync(predicate: i => i.Id == request.UpdateInstructorDto.Id, cancellationToken: cancellationToken);
            await _instructorBusinessRules.InstructorShouldExistWhenSelected(instructor);

            _mapper.Map(request.UpdateInstructorDto, instructor);
            await _instructorRepository.UpdateAsync(instructor!);

            User? user = await _userService.GetAsync(predicate: u => u.Id == instructor.UserId, cancellationToken: cancellationToken);
            await _userBusinessRules.UserShouldBeExistsWhenSelected(user);

            _mapper.Map(request.UpdateInstructorDto, user);
            await _userService.UpdateAsync(user!);

            UpdatedInstructorResponse response = _mapper.Map<UpdatedInstructorResponse>(instructor);
            return response;
        }
    }
}